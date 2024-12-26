CREATE TABLE [dbo].[QueryResponse]
(
	QueryID char(10) references CustomerQuery(QueryID),
	SrNo Char(10) not null,
	AgentID char(10) references Agent(AgentID),
	Description varchar(30) not null,
	ResponseDate datetime not null,
	primary key(QueryID,SrNo)

)
