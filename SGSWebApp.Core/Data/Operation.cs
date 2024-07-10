namespace SGSWebApp.Core.Data;

public partial class Operation : Entity
{
    public Operation(DateTime startDate, DateTime endDate, string operationType, string operatorName, string inspectionLocation, Guid containerId) 
    {
        StartDate = startDate;
        EndDate = endDate;
        OperationType = operationType;
        OperatorName = operatorName;
        InspectionLocation = inspectionLocation;
        ContainerId = containerId;
    }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OperationType { get; set; } = string.Empty;
    public string OperatorName { get; set; } = string.Empty;
    public string InspectionLocation { get; set; } = string.Empty;

    public Guid ContainerId { get; set; }
    public Container Container { get; set; }
}
