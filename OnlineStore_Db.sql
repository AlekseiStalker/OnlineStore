USE MASTER
GO

--ALTER DATABASE OnlineStore SET SINGLE_USER WITH ROLLBACK IMMEDIATE
--GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'OnlineStore')
	DROP DATABASE OnlineStore
GO

CREATE DATABASE OnlineStore
GO  

USE OnlineStore
GO

CREATE TABLE dbo.Category (Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,  
						   Name nvarchar(32) NOT NULL)  
----------------------------------------------------------------------------------- 
CREATE TABLE dbo.Product (Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,  
						  Name nvarchar(32) NOT NULL DEFAULT 'Default Name',
						  Price decimal(28, 6) NOT NULL DEFAULT 0.0,
						  CategoryId int NOT NULL, 
						  FOREIGN KEY(CategoryId) REFERENCES dbo.Category(Id) ON DELETE CASCADE) 
----------------------------------------------------------------------------------- 
CREATE TABLE dbo.[User] (Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
						Login nvarchar(32) NOT NULL,
						Password nvarchar(50) NOT NULL,
						Nickname nvarchar(20) NOT NULL DEFAULT 'Default Nickname',
						Phone nvarchar(18) NOT NULL DEFAULT 'No phone') 
----------------------------------------------------------------------------------- 
CREATE TABLE dbo.PurchaseHistory (Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
								  ProductId int NOT NULL, 
								  UserId int NOT NULL
								  FOREIGN KEY(ProductId) REFERENCES dbo.Product(Id) ON DELETE CASCADE,
								  FOREIGN KEY(UserId) REFERENCES dbo.[User](Id) ON DELETE CASCADE) 
-----------------------------------------------------------------------------------

INSERT INTO dbo.Category (Name) VALUES ('Smartphones'), ('Laptops'), ('Tablets')
GO

INSERT INTO dbo.Product (Name, Price, CategoryId) VALUES 
('iPhone 7', 9.5, 1),
('iPhone X', 15.3, 1),
('Google Pixel 2', 9, 1),
('Google Pixel 3 XL', 11.5, 1),
('Xiaomi Redmi 6', 7.5, 1),
('Xiaomi Note 7', 8.4, 1), 
('Dell', 20.5, 2),
('Asus', 15.7, 2),
('Mac', 25.5, 2),
('Lenovo', 17.6, 2), 
('iPad mini', 10, 3),
('iPad Pro', 13, 3),
('GalaxyTab', 7.5, 3),
('MediaPad', 8.5, 3)
GO 

--------------------------------------------------------------------------------------
 
CREATE VIEW dbo.ViewPurchaseHistory
AS
	SELECT p.Name as Product, c.Name as Category, u.Login as Login, Nickname
	FROM dbo.PurchaseHistory h
	JOIN dbo.[User] u ON h.UserId = u.Id
 	JOIN dbo.Product p ON h.ProductId = p.Id
	JOIN dbo.Category c ON p.CategoryId = c.Id
GO

SELECT *
FROM dbo.viewPurchaseHistory 