using System;
using System.Collections.Generic;

namespace ABZProposalLibrary.Models;

public partial class Product
{
    public string ProductID { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
