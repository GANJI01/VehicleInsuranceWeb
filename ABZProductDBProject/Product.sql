CREATE TABLE [dbo].[Product]
(
	[ProductID] CHAR(10) PRIMARY KEY, 
    [ProductName] VARCHAR(30) NOT NULL, 
    [ProductDescription] VARCHAR(100) NOT NULL, 
    [ProductUIN] CHAR(20) NOT NULL, 
    [InsuredInterests] VARCHAR(30) NOT NULL CHECK (InsuredInterests IN ('PRIVATE CAR', 'PUBLIC CAR')), 
    [PolicyCoverage] VARCHAR(100) NOT NULL
)