-- Tạo database
IF DB_ID('QuanLyShopGiay') IS NULL
    CREATE DATABASE QuanLyShopGiay;
GO

USE QuanLyShopGiay;
GO

-- Tạo bảng
IF OBJECT_ID('Product') IS NULL
CREATE TABLE Product(
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL
);

IF OBJECT_ID('Customers') IS NULL
CREATE TABLE Customers(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100)
);

IF OBJECT_ID('Employee') IS NULL
CREATE TABLE Employee(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    BirthDate DATE,
    Position NVARCHAR(50),
    PhoneNumber NVARCHAR(20)
);

IF OBJECT_ID('Supplier') IS NULL
CREATE TABLE Supplier(
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(200)
);

IF OBJECT_ID('Orders') IS NULL
CREATE TABLE Orders(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME DEFAULT GETDATE(),
    CustomerID INT,
    EmployeeID INT,
    TotalAmount DECIMAL(18,2)
);

IF OBJECT_ID('OrderDetails') IS NULL
CREATE TABLE OrderDetails(
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL(18,2)
);

-- Thêm dữ liệu mẫu cho Product
IF NOT EXISTS(SELECT 1 FROM Product)
BEGIN
    INSERT INTO Product(ProductName, Category, Price, Quantity) VALUES
    (N'Giày Nike Air Max', N'Thể thao', 2500000, 10),
    (N'Giày Adidas Ultra', N'Thể thao', 2300000, 15),
    (N'Giày Converse All', N'Casual', 900000, 20),
    (N'Giày Vans Old Skool', N'Casual', 1200000, 12),
    (N'Giày Bitis Hunter', N'Chạy bộ', 800000, 30);
END;
GO
