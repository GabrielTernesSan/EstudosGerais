\c live023

-- * = ALL
-- SELECT Id, FirstName AS "Primeiro Nome", LastName
-- FROM Customers;

-- SELECT *
-- FROM Customers
-- ORDER BY CreatedAt DESC;

SELECT *
FROM Customers
ORDER BY Id DESC
LIMIT 3;

SELECT *
FROM Orders;