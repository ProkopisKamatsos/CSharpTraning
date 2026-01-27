CREATE TABLE Departments (
 Id INT PRIMARY KEY IDENTITY,
 Name NVARCHAR(100),
 Location NVARCHAR(100),
 ManagerId INT
);
CREATE TABLE Employees (
 Id INT PRIMARY KEY IDENTITY,
 FirstName NVARCHAR(50),
 LastName NVARCHAR(50),
 Email NVARCHAR(100) UNIQUE,
 Phone NVARCHAR(20),
 DepartmentId INT,
 Salary DECIMAL(18,2),
 HireDate DATE,
 IsActive BIT DEFAULT 1,
 FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);
CREATE TABLE Projects (
 Id INT PRIMARY KEY IDENTITY,
 Name NVARCHAR(200),
 StartDate DATE,
 EndDate DATE,
 Budget DECIMAL(18,2)
);
CREATE TABLE EmployeeProjects (
 EmployeeId INT,
 ProjectId INT,
 Role NVARCHAR(50),
 PRIMARY KEY (EmployeeId, ProjectId),
 FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
 FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
);
INSERT INTO Employees
(
    FirstName,
    LastName,
    Email,
    Phone,
    DepartmentId,
    Salary,
    HireDate,
    IsActive
)
VALUES
(
    'John',
    'Doe',
    'john.doe@test.com',
    NULL,
    1,
    1200.00,
    GETDATE(),
    1
);
INSERT INTO Departments (Name, Location, ManagerId)
VALUES ('IT', 'Athens', NULL);
