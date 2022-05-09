using LunarComber.Common.Interfaces;

namespace LunarComber.Services;

public interface IPrinterConnectionManager : IAsyncDisposable
{
    IPrinterConnection CreateNewConnection(IPrinter printer);
    IPrinterConnection GetConnection(IPrinter printer);
}