using System;
using System.Collections.Generic;

namespace ABZPolicyLibrary.Models;

public partial class Proposal
{
    public string ProposalNo { get; set; } = null!;

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
