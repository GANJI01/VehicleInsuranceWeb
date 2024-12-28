using System;
using System.Collections.Generic;

namespace ABZCustomerQueryLibrary.Models;

public partial class QueryResponse
{
    public string QueryID { get; set; } = null!;

    public string SrNo { get; set; } = null!;

    public string? AgentID { get; set; }

    public string Description { get; set; } = null!;

    public DateTime ResponseDate { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual CustomerQuery? Query { get; set; } = null!;
}
