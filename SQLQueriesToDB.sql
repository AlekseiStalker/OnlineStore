
SELECT count(*) AS 'общее кол-во товаров'
FROM SportStore.dbo.Product
GO
 
SELECT count(*) AS 'общее кол-во заказов для каждого пользователя'
FROM SportStore.dbo.OrderHeader
GO

SELECT p.[Name], od.Price AS 'Сумма больше 1000', od.[Count]
FROM SportStore.dbo.OrderDetail od
JOIN SportStore.dbo.Product p ON od.ProductId = p.Id
WHERE od.Price > 1000
GO

--SELECT OrderId, SUM(od.Price) AS 'Сумма больше 10000'
--FROM SportStore.dbo.OrderDetail od
--JOIN SportStore.dbo.Product p ON od.ProductId = p.Id
--GROUP BY OrderId
--HAVING SUM(od.Price) > 10000
--GO

SELECT TOP 1 p.[Name] AS 'Продан найбольшее кол-во раз', MAX(od.[Count])
FROM SportStore.dbo.OrderDetail od
JOIN SportStore.dbo.Product p ON od.ProductId = p.Id 
GROUP BY p.Name
GO

SELECT TOP 1 a.AddressLine AS 'Aдрес был чаще все исользован в заказах'
FROM SportStore.dbo.OrderHeader oh
JOIN SportStore.dbo.[Address] a ON oh.ShippingAddressId = a.Id 
GROUP BY a.AddressLine
ORDER BY COUNT(a.AddressLine)
GO

SELECT TOP 1 Name AS 'Cамый дорогой продукт в магазине', p.Price
FROM SportStore.dbo.Product p
ORDER BY p.Price desc
GO

SELECT TOP 1 u.FirstName AS 'Пользователь оставил больше всего заказов', MAX(oh.UserId)
FROM SportStore.dbo.OrderHeader oh
JOIN SportStore.dbo.[User] u ON oh.UserId = u.Id
GROUP BY u.FirstName
GO

SELECT TOP 1 u.FirstName AS 'Пользователь купил больше всех продуктов', SUM(od.[Count])
FROM SportStore.dbo.OrderDetail od 
JOIN SportStore.dbo.OrderHeader oh On od.OrderId = oh.Id
JOIN SportStore.dbo.[User] u ON oh.UserId = u.Id
GROUP BY u.FirstName
GO
 
SELECT p.[Name] AS 'Какие товары покупал пользователь под номером 1', u.FirstName
FROM SportStore.dbo.OrderDetail od 
JOIN SportStore.dbo.OrderHeader oh On od.OrderId = oh.Id
JOIN SportStore.dbo.[User] u ON oh.UserId = u.Id 
JOIN SportStore.dbo.Product p ON od.ProductId = p.Id
WHERE u.Id = 1
GO

SELECT c2.Name AS 'Категории продуктов', c.Name
FROM SportStore.dbo.Category c 
JOIN SportStore.dbo.Category c2 ON c.ParentId = c2.Id
GO