use ABZPolicyDB;
EXEC sp_rename 'Proposal.ProposalID', 'ProposalNo', 'COLUMN';
Use ABZProposalDB;
EXEC sp_rename 'Proposal.ProposalID', 'ProposalNo', 'COLUMN';
