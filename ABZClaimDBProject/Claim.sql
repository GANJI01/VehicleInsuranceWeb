CREATE TABLE [dbo].[Claim]
(
	ClaimNo CHAR(10) NOT NULL PRIMARY KEY,
	ClaimDate DATETIME,
	PolicyNo CHAR(10) NOT NULL,
	FOREIGN KEY (PolicyNo) REFERENCES Policy(PolicyNo),
	IncidentDate DATETIME NOT NULL,
	IncidentLocation VARCHAR(50) NOT NULL,
	IncidentDescription VARCHAR(100),
	ClaimAmount MONEY NOT NULL,
	SurveyorName VARCHAR(30) NOT NULL,
	SurveyorPhone CHAR(10) NOT NULL,
	SurveyDate DATETIME,
	SurveyDescription VARCHAR(100),
	ClaimStatus CHAR(1) CHECK (ClaimStatus IN ('S', 'A', 'R', 'T')) NOT NULL,
    
);
