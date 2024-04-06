\c live023

-- * = ALL
-- SELECT Id, FirstName AS "Primeiro Nome", LastName
-- FROM Customers;

-- SELECT *
-- FROM Customers
-- ORDER BY CreatedAt DESC;

-- SELECT *
-- FROM Customers
-- ORDER BY Id DESC
-- LIMIT 3;

-- SELECT *
-- FROM Orders;

-- REGRA PAGINAÇÃO: (pag - 1) * perPage
SELECT *
FROM Customers
ORDER BY Id ASC
LIMIT 10
-- "Pula" (x) registros
OFFSET 10;

SELECT * FROM Customers
WHERE Id = 10 OR LastName like '%-9';

SELECT * FROM Customers
WHERE Id BETWEEN 5 AND 9;

SELECT * FROM Customers
WHERE Id NOT BETWEEN 5 AND 9;

--LIKE CASE INSENSITIVE
SELECT * FROM Customers
WHERE LastName ILIKE '%9';