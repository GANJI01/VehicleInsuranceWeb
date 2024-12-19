CREATE TABLE [dbo].[Customer]
(
	CustomerID CHAR(10) NOT NULL PRIMARY KEY,
	CustomerName VARCHAR(30) NOT NULL,
	CustomerPhone CHAR(10) NOT NULL,
	CustomerEmail VARCHAR(30) NOT NULL,
	CustomerAddress VARCHAR(50)
)
