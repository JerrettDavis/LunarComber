using AndreasReitberger;
using LunarComber.Common.Interfaces;
using LunarComber.Models.Notifications;
using MediatR;

namespace LunarComber.Services;

public class PrinterConnection : IPrinterConnection
{
    private readonly KlipperClient _client;
    private readonly IPublisher _publisher;
    private readonly ILogger<PrinterConnection> _logger;

    public PrinterConnection(
        IPrinter printer,
        IPublisher publisher, 
        ILogger<PrinterConnection> logger)
    {
        Printer = printer;
        _publisher = publisher;
        _logger = logger;
        _client = new KlipperClient(Printer.Host, Printer.ApiToken, Printer.Port, Printer.UseSsl);
        Id = Guid.NewGuid();
    }
    
    public IPrinter Printer { get; }
    public Guid Id { get; }

    public async Task ConnectAsync(CancellationToken cancellationToken)
    {
        await _client.CheckOnlineAsync();
        if (!_client.IsOnline)
            throw new Exception("Server is not online!");
        
        _client.WebSocketConnectionIdChanged += (_, args) =>
        {
            if (args.ConnectionId is null or <= 0)
                throw new Exception("Invalid ConnectionId");
            
            Task.Run(async () =>
            {
                var subResult = await _client.SubscribeAllPrinterObjectStatusAsync(args.ConnectionId);
                _logger.LogDebug("New all-printer-objects message {@Message}", subResult);
                await _publisher.Publish(new ObjectStatusNotification {Message = subResult}, cancellationToken);
            }, cancellationToken);
        };

        _client.Error += async (_, args) =>
        {
            _logger.LogDebug("Klipper client error {@Error}", args);
            await _publisher.Publish(
                new ClientErrorNotification
                {
                    Printer = Printer,
                    Message = args.ToString()
                }, 
                cancellationToken);
        };
        _client.ServerWentOffline += async (_, args) =>
        {
            _logger.LogDebug("Moonraker server went offline with {@Arguments}", args);
            await _publisher.Publish(
                new ServerWentOfflineNotification
                {
                    Printer = Printer,
                    Message = args.ToString()
                }, 
                cancellationToken);
        };
        _client.WebSocketDataReceived += async (_, args) =>
        {
            if (!string.IsNullOrEmpty(args.Message))
            {
                _logger.LogDebug("Received new websocket data {@Data}", args);
                await _publisher.Publish(
                    new PrinterWebsocketDataReceivedNotification
                    {
                        Printer = Printer,
                        Message = args.Message
                    }, 
                    cancellationToken);
            }
        };

        _client.WebSocketError += async (_, args) =>
        {
            _logger.LogDebug("Websocket error {@Error}", args);
            await _publisher.Publish(
                new PrinterWebsocketErrorNotification
                {
                    Printer = Printer,
                    Message = args.ToString()
                },
                cancellationToken);
        };

        _client.WebSocketDisconnected += async (_, args) =>
        {
            _logger.LogDebug("Websocket disconnected {@Arguments}", args);
            await _publisher.Publish(
                new PrinterWebsocketDisconnectedNotification
                {
                    Printer = Printer,
                    Message = args.Message
                },
                cancellationToken);
        };
        
        _client.StartListening();
    }

    public Task DisconnectAsync(CancellationToken cancellationToken)
    {
        _client?.StopListening();
        _client?.Dispose();
        
        return Task.CompletedTask;
    }
    
    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await DisconnectAsync(CancellationToken.None);
    }
}