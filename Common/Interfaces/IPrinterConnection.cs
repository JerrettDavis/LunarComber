namespace LunarComber.Common.Interfaces;

public interface IPrinterConnection : IAsyncDisposable
{
    IPrinter Printer { get; }
    Guid Id { get; }
    Task ConnectAsync(CancellationToken cancellationToken);
    Task DisconnectAsync(CancellationToken cancellationToken);
}