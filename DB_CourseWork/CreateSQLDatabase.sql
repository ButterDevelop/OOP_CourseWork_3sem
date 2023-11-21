-- Таблица для пользователей
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Salt NVARCHAR(255) NOT NULL,
    HashedPassword NVARCHAR(255) NOT NULL,
    Fullname NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Role INT NOT NULL,
    IsAccountSetupCompleted BIT NOT NULL,
    AccountDeactivated BIT NOT NULL
);

-- Таблица для клиентов
CREATE TABLE Clients (
    UserId INT PRIMARY KEY,
    DriverLicense NVARCHAR(50),
    Passport NVARCHAR(50),
    CardNumber NVARCHAR(50),
    Balance FLOAT,
    SumRating FLOAT,
    OrdersCount INT,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Таблица для администраторов
CREATE TABLE Admins (
    UserId INT PRIMARY KEY,
    TotalCarsServiced INT,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Таблица для сотрудников
CREATE TABLE Employees (
    UserId INT PRIMARY KEY,
    OrdersProcessed INT,
    DaysWorked INT,
    DateHired DATETIME,
    DateFired DATETIME,
    DateLastSalaryPayed DATETIME,
    BankAccountNumber NVARCHAR(50),
    TotalSalaryPaid FLOAT,
    IsWorkingNow BIT,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Таблица для машин
CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY,
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    CarLicensePlate NVARCHAR(50) NOT NULL,
    PricePerHour FLOAT NOT NULL,
    ProductionYear DATETIME,
    BuyTime DATETIME,
    LastServiceTime DATETIME,
    LocationX FLOAT,
    LocationY FLOAT,
    IsHidden BIT NOT NULL
);

-- Таблица для отчетов о сервисе
CREATE TABLE ServiceReports (
    Id INT PRIMARY KEY IDENTITY,
    Description NVARCHAR(255),
    StartedDate DATETIME,
    FinishedDate DATETIME,
    AdditionalCost FLOAT,
    IsStarted BIT,
    IsFinished BIT,
    PlannedCompletionDays INT,
    WorkerId INT NULL,
    ServicedCarId INT,
    EmployeeReport NVARCHAR(255),
    FOREIGN KEY (WorkerId) REFERENCES Employees(UserId),
    FOREIGN KEY (ServicedCarId) REFERENCES Cars(Id)
);

-- Таблица для платежей
CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY,
    CreatedTime DATETIME NOT NULL,
    PayedTime DATETIME,
    UserId INT,
    Cost FLOAT NOT NULL,
    IsPayed BIT NOT NULL,
    IsRefunded BIT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Таблица для заказов
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY,
    OrderCreatedTime DATETIME NOT NULL,
    OrderBookingTime DATETIME,
    OrderCancelledTime DATETIME,
    OrderedCarId INT,
    OrderedHours INT NOT NULL,
    OrderPaymentId INT,
	OrderExtendPaymentsIdsString NVARCHAR(255) NULL,
    IsCancelled BIT NOT NULL,
    FOREIGN KEY (OrderedCarId) REFERENCES Cars(Id),
    FOREIGN KEY (OrderPaymentId) REFERENCES Payments(Id)
);

-- Таблица для банковских транзакций
CREATE TABLE BankTransactions (
    Id INT PRIMARY KEY IDENTITY,
    FromCardNumberOrBankAccountNumber NVARCHAR(50),
    ToCardNumberOrBankAccountNumber NVARCHAR(50),
    UserId INT NULL,
    CreatedTime DATETIME NOT NULL,
    PayedTime DATETIME,
    CancelledTime DATETIME,
    TotalAmount FLOAT NOT NULL,
    TotalTries INT NOT NULL,
    IsFinished BIT NOT NULL,
    IsCancelled BIT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
