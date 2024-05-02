\c live024

-- SELECT Id, CONCAT(FirstName, ' ', LastName) AS "FullName"
-- FROM Customers;

--SELECT *  FROM Orders;

-- SELECT COUNT(*) AS "TotalCustomers"
-- FROM Customers;

-- SELECT * FROM Customers ORDER BY Email;

-- SELECT COUNT(Id) AS "TotalSales", SUM(Amount) AS "TotalRevenue"
-- FROM Orders;

-- SELECT Amount FROM Orders ORDER BY Amount DESC LIMIT 1;

-- Função de Agregaçãp (Aggregate Functions)
SELECT 
    CustomerId,
    COUNT(Id) AS "TotalSales", 
    SUM(Amount) AS "TotalRevenue",
    MAX(Amount) AS "OrderMoreExpensive",
    MIN(Amount) AS "OrderLessExpensive",
    ROUND(AVG(Amount), 2) AS "AvarageTicket"
FROM Orders
GROUP BY CustomerId
ORDER BY CustomerId;