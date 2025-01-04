---- Create Tables------
CREATE TABLE Member (
    MemberID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10) CHECK (Gender IN ('Male', 'Female')),
    Age INT,
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    Address VARCHAR(255),
    Role VARCHAR(20) CHECK (Role IN ('Admin', 'Customer'))
);

CREATE TABLE Trainer (
    TrainerID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10) CHECK (Gender IN ('Male', 'Female')),
    Age INT,
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    Specialization VARCHAR(100) CHECK (Specialization IN ('Fitness', 'Yoga', 'Kick Box'))
);

CREATE TABLE Membership (
    MembershipID INT PRIMARY KEY IDENTITY,
    MemberID INT,
    MembershipType VARCHAR(10) CHECK (MembershipType IN ('Year', 'Month')),
    StartDate DATE,
    EndDate DATE,
    Price DECIMAL(10, 2),
    FOREIGN KEY (MemberID) REFERENCES Member(MemberID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Class (
    ClassID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100),
    Schedule DATETIME,
    TrainerID INT,
    ClassType VARCHAR(50) CHECK (ClassType IN ('Fitness', 'Yoga', 'Kick Box')),
    FOREIGN KEY (TrainerID) REFERENCES Trainer(TrainerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY,
    MemberID INT,
    ClassID INT,
    Date DATE,
    FOREIGN KEY (MemberID) REFERENCES Member(MemberID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ClassID) REFERENCES Class(ClassID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY,
    MemberID INT,
    Amount DECIMAL(10, 2),
    PaymentDate DATE,
    PaymentStatus TINYINT CHECK (PaymentStatus IN (1, 0)),
    FOREIGN KEY (MemberID) REFERENCES Member(MemberID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE UserAuth (
    UserID INT PRIMARY KEY IDENTITY,
    MemberID INT,
    Username VARCHAR(50) UNIQUE,
    Password VARCHAR(100),
    FOREIGN KEY (MemberID) REFERENCES Member(MemberID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2),
    Stock INT
);

CREATE TABLE Purchase (
    PurchaseID INT PRIMARY KEY IDENTITY,
    MemberID INT,
    ProductID INT,
    Quantity INT,
    PurchaseDate DATETIME,
    FOREIGN KEY (MemberID) REFERENCES Member(MemberID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Equipment (
    EquipmentID INT PRIMARY KEY IDENTITY,
    EquipmentName VARCHAR(100),
    Quantity INT,
    Condition VARCHAR(50) CHECK (Condition IN ('Good', 'Needs Repair', 'Broken'))
);

--DEFAULT ADMIN CREATION
INSERT INTO Member (FirstName, LastName, Gender, Age, PhoneNumber, Email, Address, Role)
VALUES ('Admin', 'User', 'Male', 30, '1234567890', 'admin@example.com', 'Admin Address', 'Admin');

SELECT SCOPE_IDENTITY() AS NewMemberID;

INSERT INTO UserAuth (MemberID, Username, Password)
VALUES (1, 'admin', 'admin');

--INSERT INFORMATIONS INTO EQUÝPMENT TABLE (DEFAULT)
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Treadmill', 5, 'Good'); -- Koþu Bandý
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Stationary Bike', 7, 'Good'); -- Sabit Bisiklet
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Rowing Machine', 4, 'Needs Repair'); -- Kürek Çekme Makinesi
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Elliptical Trainer', 6, 'Good'); -- Eliptik Bisiklet
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Smith Machine', 2, 'Good'); -- Smith Makinesi
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Dumbbell Set', 20, 'Good'); -- Dambýl Seti
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Kettlebell Set', 15, 'Good'); -- Kettlebell Seti
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Lat Pulldown Machine', 3, 'Good'); -- Lat Pulldown Makinesi
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Leg Press Machine', 4, 'Good'); -- Bacak Pres Makinesi
INSERT INTO Equipment (EquipmentName, Quantity, Condition) VALUES ('Dumbbell', 30, 'Good'); -- Dumbel aleti


-- INSERT DEFAULT PRODUCTS IN PRODUCT TABLE
INSERT INTO Product (ProductName, Price, Stock)
VALUES 
('Protein Bar', 50.00, 50),
('Whey Protein', 500.00, 30),
('Workout Gloves', 100.00, 20),
('Water Bottle', 10.00, 100),
('BCAA Powder', 200.00, 15),
('Yoga Mat', 120.00, 10),
('Resistance Band', 50.00, 25),
('Energy Drink', 30.00, 60),
('Towel', 100.00, 50);

--PROCEDURE

CREATE PROCEDURE GetMemberClasses
    @MemberID INT
AS
BEGIN
    SELECT 
        C.Name AS ClassName,
        C.Schedule,
        C.ClassType,
        CONCAT(T.FirstName, ' ', T.LastName) AS TrainerFullName
    FROM 
        Attendance A
    INNER JOIN 
        Class C ON A.ClassID = C.ClassID
    INNER JOIN 
        Trainer T ON C.TrainerID = T.TrainerID
    WHERE 
        A.MemberID = @MemberID
END;

--TRIGGER

CREATE TRIGGER trg_CheckMembershipExpiration
ON UserAuth
AFTER INSERT
AS
BEGIN
    -- Giriþ yapan kullanýcýyý al
    DECLARE @MemberID INT;
    SELECT @MemberID = MemberID FROM inserted;  

    -- Giriþ yapan üyenin bitiþ tarihini sorgula
    DECLARE @EndDate DATE;
    SELECT @EndDate = EndDate  -- 'ExpirationDate' yerine doðru sütun adý
    FROM Membership
    WHERE MemberID = @MemberID;

    -- Eðer üyelik bitiþ tarihi 27 günden daha yakýnsa bildirim yapýlacak
    IF (@EndDate <= DATEADD(DAY, 27, GETDATE()))
    BEGIN
        -- Bu noktada bir bildirim yapabilirsiniz. Ancak SQL ile sadece veritabaný iþlemleri yapýlabilir.
        PRINT 'Your membership expiration date is approaching. Please make a payment.';  -- Örnek bildirim
    END
END