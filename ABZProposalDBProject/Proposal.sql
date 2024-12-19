CREATE TABLE [dbo].[Proposal]
(
	ProposalID CHAR(10) NOT NULL PRIMARY KEY,
    RegNo CHAR(10) NOT NULL,          
    ProductID CHAR(10) NOT NULL,      
    CustomerID CHAR(10) NOT NULL,    
    FromDate DATETIME NOT NULL, 
    ToDate DATETIME NOT NULL,       
    IDV MONEY NOT NULL, 
    AgentID CHAR(10) NOT NULL,        
    BasicAmount MONEY, 
    TotalAmount MONEY, 
    FOREIGN KEY (RegNo) REFERENCES Vehicle(RegNo),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (AgentID) REFERENCES Agent(AgentID)
)
