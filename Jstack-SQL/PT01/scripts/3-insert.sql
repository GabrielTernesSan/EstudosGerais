\c live023

-- INSERT INTO Customers 
-- VALUES (DEFAULT, 'Gabriel', 'Santos', DEFAULT, 'gabriel.emailTest@gmail.com');

-- INSERT INTO Customers (Email, FirstName, LastName)
-- VALUES ('junior.emailTest@gmail.com', 'Junior', 'Silva');

-- INSERT INTO Customers (Email, FirstName, LastName)
-- VALUES ('mattuardo.emailTest@gmail.com', 'Matheus', 'Eduardo');

-- INSERT INTO Customers (Email, FirstName, LastName)
-- VALUES ('rose.emailTest@gmail.com', 'Rose', 'Silva');

-- INSERT INTO Customers (Email, FirstName, LastName)
-- VALUES 
--     ('mattuardo.emailTest@gmail.com', 'Matheus', 'Eduardo'),
--     ('rose.emailTest@gmail.com', 'Rose', 'Silva');

-- INSERT INTO Customers (Email, FirstName, LastName)
-- VALUES
--     ('mattuardo.emailTest@gmail.com', 'Matheus', 'Eduardo'),
--     ('rose.emailTest@gmail.com', 'Rose', 'Silva'),
--     ('tiago.emailTest@gmail.com', 'Tiago', 'Silva')
-- RETURNING Id, CreatedAt;

-- INSERT INTO Customers (Email, FirstName, LastName)
-- VALUES ('rose.emailTest@gmail.com', 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 'Silva');

DO $$ 
DECLARE
    i INT := 1;
    customerId INT;
BEGIN -- Inicia uma TRANSACTION
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