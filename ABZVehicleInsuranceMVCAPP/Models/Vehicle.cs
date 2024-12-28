using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Vehicle
    {
        [RegularExpression(@"\w[10]", ErrorMessage ="RegNo must be 10 characters")]
        public string RegNo { get; set; } = null!;
        [Required]
        public string RegAuthority { get; set; } = null!;
        [Required]
        public string Make { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [RegularExpression(@"\w[1]", ErrorMessage = "FuelType in('P','D','C','L','E')")]
        public string FuelType { get; set; } = null!;
        [Required]
        public string Variant { get; set; } = null!;
        [Required]
        public string EngineNo { get; set; } = null!;
        [Required]
        public string ChassisNo { get; set; } = null!;
        [Required]
        public int EngineCapacity { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }
        [Required]
        public string MfgYear { get; set; } = null!;
        [Required]
        public DateTime RegDate { get; set; }
        [Required]
        public string BodyType { get; set; } = null!;
        [Required]
        public string? LeasedBy { get; set; }
        [RegularExpression(@"\w[10]", ErrorMessage = "OwnerId must be 10 characters")]
        public string OwnerId { get; set; } = null!;

        
    }
}
