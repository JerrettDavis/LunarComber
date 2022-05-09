namespace LunarComber.Models.Klipper.Status;

public class BedMesh
{
    // public double HorizontalMove { get; set; }
    // public BedMeshAlgorithm Algorithm { get; set; }
    // public TwoDimensionValue<int> MeshMin { get; set; }
    // public TwoDimensionValue<int> MeshMax { get; set;}
    // public TwoDimensionValue<int> ProbeCount { get; set; }
    // public TwoDimensionValue<int> MeshPPs { get; set; }
    // public double BicubicTension { get; set; }
    
    public IEnumerable<int> MeshMin { get; set; }
    public IEnumerable<int> MeshMax { get; set; }
    public IEnumerable<IEnumerable<double>> ProbedMatrix { get; set; }
    public IEnumerable<BedMeshProfile> Profiles { get; set; }
}

public class BedMeshProfile
{
    public string Name { get; set; }
    public IEnumerable<IEnumerable<double>> Points { get; set; }
    public BedMeshProfileMeshParams MeshParams { get; set; }
}

public class BedMeshProfileMeshParams
{
    public double Tension { get; set; }
    public int MeshXPPs { get; set; }
    public int MeshYPPs { get; set; }
    public BedMeshAlgorithm Algorithm { get; set; }
    public int MinX { get; set; }
    public int MinY { get; set; }
    public int YCount { get; set; }
    public int XCount { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
}