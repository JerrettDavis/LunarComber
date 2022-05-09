using LunarComber.Models.Notifications;
using MediatR;

namespace LunarComber.NotificationHandlers;

public class PrinterWebsocketDataReceivedNotificationHandler :
    INotificationHandler<PrinterWebsocketDataReceivedNotification>
{
    private readonly ILogger<PrinterWebsocketDataReceivedNotificationHandler> _logger;

    public PrinterWebsocketDataReceivedNotificationHandler(
        ILogger<PrinterWebsocketDataReceivedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(
        PrinterWebsocketDataReceivedNotification notification, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received notification {@Notification}", notification);
        
        return Task.CompletedTask;
    }
}