namespace LunarComber.Models.Klipper.Status;

public class GcodeMacro
{
    public string Name { get; set; }
    public Dictionary<string,object> Parameters { get; set; }
}