using System;
using System.Collections.Generic;

namespace ABZPolicyLibrary.Models;

public partial class Policy
{
    public string PolicyNo { get; set; } = null!;

    public string? ProposalNo { get; set; }

    public decimal? NoClaimBonus { get; set; }

    public string ReceiptNo { get; set; } = null!;

    public DateTime ReceiptDate { get; set; }

    public string PaymentMode { get; set; } = null!;

    public decimal? Amount { get; set; }

    public virtual ICollection<PolicyAddon> PolicyAddons { get; set; } = new List<PolicyAddon>();

    public virtual Proposal? PrososalNoNavigation { get; set; }
}
