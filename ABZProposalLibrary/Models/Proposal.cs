using System;
using System.Collections.Generic;

namespace ABZProposalLibrary.Models;

public partial class Proposal
{
    public string ProposalNo { get; set; } = null!;

    public string RegNo { get; set; } = null!;

    public string ProductID { get; set; } = null!;

    public string CustomerID { get; set; } = null!;

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    public decimal IDV { get; set; }

    public string AgentID { get; set; } = null!;

    public decimal? BasicAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Agent? Agent { get; set; } = null!;

    public virtual Customer? Customer { get; set; } = null!;

    public virtual Product? Product { get; set; } = null!;

    public virtual Vehicle? RegNoNavigation { get; set; } = null!;
}
