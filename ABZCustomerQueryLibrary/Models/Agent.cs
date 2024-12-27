using System;
using System.Collections.Generic;

namespace ABZCustomerQueryLibrary.Models;

public partial class Agent
{
    public string AgentID { get; set; } = null!;

    public virtual ICollection<QueryResponse> QueryResponses { get; set; } = new List<QueryResponse>();
}
