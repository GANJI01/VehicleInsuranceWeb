using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Claim
    {
        [RegularExpression(@"\w{10}", ErrorMessage = "Claim ID must be 10 Characters")]
        public string ClaimNo { get; set; } = null!;
        [Required]
        public DateTime? ClaimDate { get; set; }
        [RegularExpression(@"\w{10}", ErrorMessage = "Policy No must be 10 Characters")]
        public string PolicyNo { get; set; } = null!;
        [Required]
        public DateTime IncidentDate { get; set; }
        [Required]
        public string IncidentLocation { get; set; } = null!;
        [Required]
        public string? IncidentDescription { get; set; }
        [Required]
        public decimal ClaimAmount { get; set; }
        [Required]
        public string SurveyorName { get; set; } = null!;
        [RegularExpression(@"\d{10}", ErrorMessage = "SurveyorPhone  must be 10 digit")]
        public string SurveyorPhone { get; set; } = null!;
        [Required]
        public DateTime? SurveyDate { get; set; }
        [Required]
        public string? SurveyDescription { get; set; }
        [RegularExpression(@"\w{1}", ErrorMessage = "Status should be S/A/R/T")]
        public string ClaimStatus { get; set; } = null!;
    }
}
