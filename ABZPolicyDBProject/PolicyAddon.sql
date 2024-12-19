CREATE TABLE [dbo].[PolicyAddon]
(
     AddonID char(4),
	 PolicyNo char(10) references Policy(PolicyNo),
	 Amount money,
	 primary key(AddonID,PolicyNo)

)
