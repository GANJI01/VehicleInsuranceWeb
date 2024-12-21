using System;
using System.Collections.Generic;

namespace ABZProductLibrary.Models;

public partial class Product
{
    public string ProductID { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string ProductUIN { get; set; } = null!;

    public string InsuredInterests { get; set; } = null!;

    public string PolicyCoverage { get; set; } = null!;

    public virtual ICollection<ProductAddon> ProductAddons { get; set; } = new List<ProductAddon>();
}
