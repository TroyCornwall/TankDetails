namespace GraphTankDetails.Models;

public class ApexExtract
{
    public DateTimeOffset Timestamp { get; set; }
    public string ApexName { get; set; } = null!;
    public double Temp { get; set; }
    public double Ph { get; set; }
    public double Alk { get; set; }
    public double Calc { get; set; }
    public double Mg { get; set; }
    public Output? ATO { get; set; }
    public bool ATOLow { get; set; }
    public bool ATOHigh { get; set; }
}
public class Output
{
    public List<string> status { get; set; }
    public string name { get; set; }
}