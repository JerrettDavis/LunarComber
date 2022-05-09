namespace LunarComber.Models.Klipper.Status;

public class FirmwareRetraction
{
    public double RetractLength { get; set; }
    public double RetractSpeed { get; set; }
    public double UnretractExtraLength { get; set; }
    public double UnretractSpeed { get; set; }
}