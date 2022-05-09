namespace LunarComber.Models.Klipper.Status;

public class Heater
{
    public double Temperature { get; set; }
    public double Target { get; set; }
    public double Power { get; set; }
    public bool CanExtrude { get; set; }
}