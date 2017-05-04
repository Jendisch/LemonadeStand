CREATE TABLE Saved_Games
(
ID int IDENTITY(1,1) PRIMARY KEY,
Player_Name varchar (50) NOT NULL,
Current_Wallet decimal,
Current_Day int,
Length_Of_Game int,
Cup_Inventory int,
Lemon_Inventoy int,
Sugar_Inventory int,
Ice_Inventory int,
Net_Money decimal,
Unique_Name varchar (50) NOT NULL
);

INSERT INTO Saved_Games VALUES ('Jennifer', 75.00, 5, 7, 100, 75, 50, 0, 45.00, 'Jendisch')

SELECT Unique_Name FROM Saved_Games
WHERE Unique_Name LIKE '%sample_text%';

SELECT * FROM Saved_Games;