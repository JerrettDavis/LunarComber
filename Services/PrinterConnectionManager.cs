using System.Collections.Concurrent;
using LunarComber.Common.Exceptions.Printers;
using LunarComber.Common.Interfaces;
using MediatR;

namespace LunarComber.Services;

public class PrinterConnectionManager : IPrinterConnectionManager
{
    private readonly IPublisher _publisher;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ConcurrentDictionary<IPrinter, IPrinterConnection> _connections;

    public PrinterConnectionManager(IPublisher publisher, 
        ILoggerFactory loggerFactory)
    {
        _publisher = publisher;
        _loggerFactory = loggerFactory;
        _connections = new ConcurrentDictionary<IPrinter, IPrinterConnection>();
    }

    public IPrinterConnection CreateNewConnection(IPrinter printer)
    {
        if (_connections.ContainsKey(printer))
            throw new PrinterConnectionAlreadyExists(printer);
        
        var connection = new PrinterConnection(printer, _publisher, _loggerFactory.CreateLogger<PrinterConnection>());

        return _connections.GetOrAdd(printer, connection);
    }

    public IPrinterConnection GetConnection(IPrinter printer)
    {
        return _connections[printer];
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        foreach (var item in _connections) await item.Value.DisposeAsync();
    }
}