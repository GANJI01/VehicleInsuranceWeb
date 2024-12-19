using System;
using System.Collections.Generic;

namespace ABZVehicleLibrary.Models;

public partial class Vehicle
{
    public string RegNo { get; set; } = null!;

    public string RegAuthority { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string FuelType { get; set; } = null!;

    public string Variant { get; set; } = null!;

    public string EngineNo { get; set; } = null!;

    public string ChassisNo { get; set; } = null!;

    public int EngineCapacity { get; set; }

    public int SeatingCapacity { get; set; }

    public string MfgYear { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string BodyType { get; set; } = null!;

    public string? LeasedBy { get; set; }

    public string OwnerId { get; set; } = null!;

    public virtual Customer? Owner { get; set; } = null!;
}
