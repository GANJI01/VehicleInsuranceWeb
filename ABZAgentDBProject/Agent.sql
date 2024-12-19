CREATE TABLE [dbo].[Agent]
(
	AgentID CHAR(10) NOT NULL PRIMARY KEY,        
    AgentName VARCHAR(30) NOT NULL, 
    AgentPhone CHAR(10) NOT NULL, 
    AgentEmail VARCHAR(30) NOT NULL,
    LicenseCode VARCHAR(10) NOT NULL
)
