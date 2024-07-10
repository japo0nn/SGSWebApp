CREATE DATABASE sgs_db;
GO
USE sgs_db;
GO
CREATE TABLE Containers (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Number INT NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Length INT NOT NULL,
    Width INT NOT NULL,
    Height INT NOT NULL,
    Weight INT NOT NULL,
    IsEmpty BIT NOT NULL,
    ArrivalDate DATETIME NOT NULL
);

CREATE TABLE Operations (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ContainerId UNIQUEIDENTIFIER NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    OperationType NVARCHAR(50) NOT NULL,
    OperatorName NVARCHAR(100) NOT NULL,
    InspectionLocation NVARCHAR(100) NOT NULL,
    FOREIGN KEY (ContainerID) REFERENCES Containers(ID)
);

INSERT INTO Containers (Number, Type, Length, Width, Height, Weight, IsEmpty, ArrivalDate)
VALUES 
(1, 'Type A', 20, 8, 8, 2000, 0, '2024-07-10T08:00:00'),
(2, 'Type B', 40, 8, 8, 4000, 1, '2024-07-10T09:00:00');

-- Добавление записей в таблицу Operations
INSERT INTO Operations (ContainerID, StartDate, EndDate, OperationType, OperatorName, InspectionLocation)
VALUES 
((SELECT ID FROM Containers WHERE Number = 1), '2024-07-10T10:00:00', '2024-07-15T12:00:00', 'Loading', 'John Doe', 'Port A'),
((SELECT ID FROM Containers WHERE Number = 2), '2024-07-10T11:00:00', '2024-07-16T13:00:00', 'Unloading', 'Jane Smith', 'Port B');