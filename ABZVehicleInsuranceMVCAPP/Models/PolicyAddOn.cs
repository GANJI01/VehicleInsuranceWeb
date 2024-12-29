using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class PolicyAddon
    {
        [RegularExpression(@"\w{4}", ErrorMessage = "AddonID must be 4 Characters")]
        public string AddonID { get; set; } = null!;
        [RegularExpression(@"\w{10}", ErrorMessage = "PolicyNo must be 10 digit")]
        public string PolicyNo { get; set; } = null!;
        [Required]
        public decimal? Amount { get; set; }

    }
}
