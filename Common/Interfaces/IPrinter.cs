namespace LunarComber.Common.Interfaces;

public interface IPrinter
{
    string Host { get; init; }
    int Port { get; init; }
    string? ApiToken { get; init; }
    bool UseSsl { get; init; }
}