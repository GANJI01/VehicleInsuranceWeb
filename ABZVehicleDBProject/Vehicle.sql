CREATE TABLE [dbo].[Vehicle]
(
	RegNo CHAR(10) PRIMARY KEY,
	RegAuthority VARCHAR(20) NOT NULL,
	Make VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	FuelType CHAR(1) check (FuelType in('P','D','C','L','E')) NOT NULL,
	Variant VARCHAR(10) NOT NULL,
	EngineNo VARCHAR(20) NOT NULL,
	ChassisNo VARCHAR(20) NOT NULL,
	EngineCapacity INT NOT NULL,
	SeatingCapacity INT NOT NULL,
	MfgYear CHAR(4) NOT NULL,
	RegDate DATETIME NOT NULL,
	BodyType VARCHAR(10) NOT NULL,
	LeasedBy VARCHAR(20) NULL,
	OwnerId CHAR(10) NOT NULL,
	FOREIGN KEY (OwnerId) references Customer(CustomerId)
)
