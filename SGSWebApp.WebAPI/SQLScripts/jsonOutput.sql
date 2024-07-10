SELECT 
    '{' +
    '"ID":"' + CAST(Id AS NVARCHAR(36)) + '",' +
    '"Number":' + CAST(Number AS NVARCHAR(10)) + ',' +
    '"Type":"' + Type + '",' +
    '"Length":' + CAST(Length AS NVARCHAR(10)) + ',' +
    '"Width":' + CAST(Width AS NVARCHAR(10)) + ',' +
    '"Height":' + CAST(Height AS NVARCHAR(10)) + ',' +
    '"Weight":' + CAST(Weight AS NVARCHAR(10)) + ',' +
    '"IsEmpty":' + CAST(IsEmpty AS NVARCHAR(1)) + ',' +
    '"ArrivalDate":"' + CONVERT(NVARCHAR, ArrivalDate, 126) + '"' +
    '}' AS Containers_JSON
FROM Containers;

DECLARE @ContainerID UNIQUEIDENTIFIER = (SELECT ID FROM Containers WHERE Number = 1);

SELECT 
    '{' +
    '"ID":"' + CAST(ID AS NVARCHAR(36)) + '",' +
    '"ContainerID":"' + CAST(ContainerID AS NVARCHAR(36)) + '",' +
    '"StartDate":"' + CONVERT(NVARCHAR, StartDate, 126) + '",' +
    '"EndDate":"' + CONVERT(NVARCHAR, EndDate, 126) + '",' +
    '"OperationType":"' + OperationType + '",' +
    '"OperatorName":"' + OperatorName + '",' +
    '"InspectionLocation":"' + InspectionLocation + '"' +
    '}' AS Operations_JSON
FROM Operations
WHERE ContainerID = @ContainerID;