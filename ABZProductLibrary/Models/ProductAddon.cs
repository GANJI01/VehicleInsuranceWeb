using System;
using System.Collections.Generic;

namespace ABZProductLibrary.Models;

public partial class ProductAddon
{
    public string ProductID { get; set; } = null!;

    public string AddonID { get; set; } = null!;

    public string AddonTitle { get; set; } = null!;

    public string AddonDescription { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
