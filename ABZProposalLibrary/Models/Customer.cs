using System;
using System.Collections.Generic;

namespace ABZProposalLibrary.Models;

public partial class Customer
{
    public string CustomerID { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
