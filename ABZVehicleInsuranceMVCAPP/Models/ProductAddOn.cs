using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class ProductAddon
    {
        [RegularExpression(@"\w{10}", ErrorMessage = "Product Id must be 10 characters")]
        public string ProductID { get; set; } = null!;
        [RegularExpression(@"\w{10}", ErrorMessage = "Addon Id must be 10 characters")]
        public string AddonID { get; set; } = null!;
        [Required]
        public string AddonTitle { get; set; } = null!;
        [Required]
        public string AddonDescription { get; set; } = null!;

    }
}
