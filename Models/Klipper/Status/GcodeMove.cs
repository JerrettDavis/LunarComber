namespace LunarComber.Models.Klipper.Status;

public class GcodeMove
{
    public IEnumerable<double> HomingOrigin { get; set; }
    public double SpeedFactor { get; set; }
    public IEnumerable<double> GcodePosition { get; set; }
    public bool AbsoluteExtrude { get; set; }
    public bool AbsoluteCoordinates { get; set; }
    public IEnumerable<double> Position { get; set; }
    public double Speed { get; set; }
    public double ExtrudeFactor { get; set; }
}