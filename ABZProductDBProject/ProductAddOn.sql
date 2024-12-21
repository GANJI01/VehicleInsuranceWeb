CREATE TABLE [dbo].[ProductAddon]
(
	[ProductID] CHAR(10),
	[AddonID] CHAR(10), 
    [AddonTitle] VARCHAR(20) NOT NULL, 
    [AddonDescription] VARCHAR(100) NOT NULL, 
    PRIMARY KEY (ProductID, AddonID),
	FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
)