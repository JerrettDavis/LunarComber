using LunarComber.Common.Interfaces;

namespace LunarComber.Models.Printers;

public class Printer : IPrinter
{
    public string Host { get; init; }
    public int Port { get; init; }
    public string? ApiToken { get; init; }
    public bool UseSsl { get; init; }
    
    

    protected bool Equals(Printer other)
    {
        return Host == other.Host &&
               Port == other.Port;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Printer) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Host, Port);
    }
}