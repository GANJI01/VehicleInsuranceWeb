CREATE TABLE [dbo].[CustomerQuery]
(
	QueryID Char(10) NOT NULL PRIMARY KEY,
	CustomerID char(10) references Customer(CustomerId),
	Description varchar(30) not null,
	QueryDate datetime,
	Status char(1) check(Status in ('A','R')) not null
)
