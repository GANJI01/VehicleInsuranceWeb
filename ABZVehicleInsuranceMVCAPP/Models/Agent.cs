using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Agent
    {
        [RegularExpression(@"\w{10}", ErrorMessage = "Agent ID must be 10 Characters")]
        public string AgentID { get; set; } = null!;
        [Required]
        public string AgentName { get; set; } = null!;
        [RegularExpression(@"\d{10}", ErrorMessage = "Phone No must be 10 digit")]
        public string AgentPhone { get; set; } = null!;
        [Required]
        public string AgentEmail { get; set; } = null!;
        [Required]
        public string LicenseCode { get; set; } = null!;
    }
}
