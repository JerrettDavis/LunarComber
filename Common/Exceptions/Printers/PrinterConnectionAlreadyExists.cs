using LunarComber.Common.Interfaces;

namespace LunarComber.Common.Exceptions.Printers;

public class PrinterConnectionAlreadyExists : Exception
{
    public PrinterConnectionAlreadyExists(IPrinter printer) : 
        base($"Printer '{printer}' already exists!")
    {
        
    } 
}