namespace LunarComber.Models.Klipper.Status;

public class FilamentSensor
{
    public string Name { get; set; }
    public bool FilamentDetected { get; set; }
    public bool Enabled { get; set; }
}

public class FilamentSwitchSensor : FilamentSensor {}
public class FilamentMotionSensor : FilamentSensor {}