using System;
using System.Collections.Generic;

namespace ABZQueryLibrary.Models;

public partial class CustomerQuery
{
    public string QueryID { get; set; } = null!;

    public string? CustomerID { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? QueryDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<QueryResponse> QueryResponses { get; set; } = new List<QueryResponse>();
}
