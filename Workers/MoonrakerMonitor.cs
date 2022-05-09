using LunarComber.Models.Printers;
using LunarComber.Services;
using MediatR;

namespace LunarComber.Workers;

public class MoonrakerMonitor : BackgroundService
{
    private readonly IPrinterConnectionManager _connectionManager;

    public MoonrakerMonitor(
        IPrinterConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var printer = new Printer
        {
            Host = "192.168.0.9",
            Port = 7125,
            ApiToken = null,
            UseSsl = false
        };
        var connection = _connectionManager.CreateNewConnection(printer);
        
        await connection.ConnectAsync(stoppingToken);
    }
}