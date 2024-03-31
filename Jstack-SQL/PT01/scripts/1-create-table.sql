-- DROP TABLE IF EXISTS Customers;

CREATE TABLE IF NOT EXISTS Customers (
    -- Auto Increment
    Id SERIAL,
    -- char (CHARACTER)
    -- varchar (VARIABLE CHARACTER)(Até 20)
    FirstName VARCHAR(20),
    LastName VARCHAR(60),
    CreatedAt TIMESTAMP DEFAULT NOW()
);