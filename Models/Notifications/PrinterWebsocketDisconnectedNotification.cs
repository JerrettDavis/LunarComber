using LunarComber.Common.Interfaces;
using MediatR;

namespace LunarComber.Models.Notifications;

public class PrinterWebsocketDisconnectedNotification : INotification
{
    public IPrinter Printer { get; init; }
    public string? Message { get; set; }
}