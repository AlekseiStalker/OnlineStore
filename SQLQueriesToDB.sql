
SELECT count(*) AS '����� ���-�� �������'
FROM SportStore.dbo.Product
GO
 
SELECT count(*) AS '����� ���-�� ������� ��� ������� ������������'
FROM SportStore.dbo.OrderHeader
GO

SELECT p.[Name], od.Price AS '����� ������ 1000', od.[Count]
FROM SportStore.dbo.OrderDetail od
JOIN SportStore.dbo.Product p ON od.ProductId = p.Id
WHERE od.Price > 1000
GO

--SELECT OrderId, SUM(od.Price) AS '����� ������ 10000'
--FROM SportStore.dbo.OrderDetail od
--JOIN SportStore.dbo.Product p ON od.ProductId = p.Id
--GROUP BY OrderId
--HAVING SUM(od.Price) > 10000
--GO

SELECT TOP 1 p.[Name] AS '������ ���������� ���-�� ���', MAX(od.[Count])
FROM SportStore.dbo.OrderDetail od
JOIN SportStore.dbo.Product p ON od.ProductId = p.Id 
GROUP BY p.Name
GO

SELECT TOP 1 a.AddressLine AS 'A���� ��� ���� ��� ���������� � �������'
FROM SportStore.dbo.OrderHeader oh
JOIN SportStore.dbo.[Address] a ON oh.ShippingAddressId = a.Id 
GROUP BY a.AddressLine
ORDER BY COUNT(a.AddressLine)
GO

SELECT TOP 1 Name AS 'C���� ������� ������� � ��������', p.Price
FROM SportStore.dbo.Product p
ORDER BY p.Price desc
GO

SELECT TOP 1 u.FirstName AS '������������ ������� ������ ����� �������', MAX(oh.UserId)
FROM SportStore.dbo.OrderHeader oh
JOIN SportStore.dbo.[User] u ON oh.UserId = u.Id
GROUP BY u.FirstName
GO

SELECT TOP 1 u.FirstName AS '������������ ����� ������ ���� ���������', SUM(od.[Count])
FROM SportStore.dbo.OrderDetail od 
JOIN SportStore.dbo.OrderHeader oh On od.OrderId = oh.Id
JOIN SportStore.dbo.[User] u ON oh.UserId = u.Id
GROUP BY u.FirstName
GO
 
SELECT p.[Name] AS '����� ������ ������� ������������ ��� ������� 1', u.FirstName
FROM SportStore.dbo.OrderDetail od 
JOIN SportStore.dbo.OrderHeader oh On od.OrderId = oh.Id
JOIN SportStore.dbo.[User] u ON oh.UserId = u.Id 
JOIN SportStore.dbo.Product p ON od.ProductId = p.Id
WHERE u.Id = 1
GO

SELECT c2.Name AS '��������� ���������', c.Name
FROM SportStore.dbo.Category c 
JOIN SportStore.dbo.Category c2 ON c.ParentId = c2.Id
GO