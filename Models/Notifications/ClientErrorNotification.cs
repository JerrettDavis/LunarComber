using LunarComber.Common.Interfaces;
using MediatR;

namespace LunarComber.Models.Notifications;

public class ClientErrorNotification : INotification
{
    public IPrinter Printer { get; init; }
    public string? Message { get; init; }
}