using LunarComber.Common.Interfaces;
using MediatR;

namespace LunarComber.Models.Notifications;

public class PrinterWebsocketDataReceivedNotification : INotification
{
    public IPrinter Printer { get; init; }
    public string? Message { get; set; }
}