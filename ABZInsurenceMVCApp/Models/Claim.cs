namespace ABZInsurenceMVCApp.Models
{
    public class Claim
    {
        public string IncidentLocation { get; set; } = null!;

        public string? IncidentDescription { get; set; }

        public decimal ClaimAmount { get; set; }

        public string SurveyorName { get; set; } = null!;

        public string SurveyorPhone { get; set; } = null!;

        public DateTime? SurveyDate { get; set; }

        public string? SurveyDescription { get; set; }

        public string ClaimStatus { get; set; } = null!;

       
    }
}
