namespace SGSWebApp.Core.Data;

public partial class Container : Entity
{
    public Container(int number, string type, int length, int width, int height, int weight, bool isEmpty, DateTime arrivalDate)
    {
        Number = number;
        Type = type;
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
        IsEmpty = isEmpty;
        ArrivalDate = arrivalDate;
    }

    public int Number { get; set; }
    public string Type { get; set; } = string.Empty;
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public bool IsEmpty { get; set; }
    public DateTime ArrivalDate { get; set; }
    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
