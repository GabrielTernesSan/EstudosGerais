\c live023

DROP TABLE IF EXISTS Customers;

CREATE TABLE IF NOT EXISTS Customers (
    -- Auto Increment
    Id SERIAL,
    -- char (CHARACTER)
    -- varchar (VARIABLE CHARACTER)(Até 20)
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

-- NUMERIC (*primeiro dígito: número máximo de digitos*, *segundo dígito: número máximo de dígitos depois da vírgula*)
--          Contando com as casas decimais