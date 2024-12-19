using System;
using System.Collections.Generic;

namespace ABZClaimsLibrary.Models;

public partial class Policy
{
    public string PolicyNo { get; set; } = null!;

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
}
