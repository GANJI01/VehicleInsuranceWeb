CREATE TABLE [dbo].[Policy]
(
	PolicyNo char(10) PRIMARY KEY,
	PrososalNo char(10) references Proposal(ProposalID),
	NoClaimBonus money,
	ReceiptNo char(5) not null,
	ReceiptDate Datetime not null,
	PaymentMode char(1) check (PaymentMode in ('C','Q','U','D')) not null,
	Amount money 

)
