using System;
using System.Collections.Generic;

namespace ABZPolicyLibrary.Models;

public partial class PolicyAddon
{
    public string AddonID { get; set; } = null!;

    public string PolicyNo { get; set; } = null!;

    public decimal? Amount { get; set; }

    public virtual Policy? PolicyNoNavigation { get; set; } = null!;
}
