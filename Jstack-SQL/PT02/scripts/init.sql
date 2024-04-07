-- CREATE DATABASE
DROP DATABASE IF EXISTS live024;
CREATE DATABASE live024;

\c live024

-- CREATE TABLES
DROP TABLE IF EXISTS Customers;
CREATE TABLE IF NOT EXISTS Customers (
    Id SERIAL,
    FirstName VARCHAR(20),
    LastName VARCHAR(60),
    Email VARCHAR(256),
    CreatedAt TIMESTAMP DEFAULT NOW()
);

DROP TABLE IF EXISTS Orders;
CREATE TABLE IF NOT EXISTS Orders (
    Id SERIAL,
    CustomerId INT,
    Amount NUMERIC(7, 2)
);

-- SEED DB
DO $$ 
DECLARE
    i INT := 1;
    customerId INT;
BEGIN
    WHILE i <= 20 LOOP
        
        INSERT INTO Customers (FirstName, LastName, Email)
        VALUES ('Customer-' || i, 'Doe-' || i, 'customer' || i || '@email.com')
        RETURNING Id INTO customerId;

        INSERT INTO Orders (Amount, CustomerId)
        VALUES (RANDOM() * 1000, customerId);

        i := i + 1;
    END LOOP;

    RAISE NOTICE '% customers succesfully created', i - 1;
END $$;