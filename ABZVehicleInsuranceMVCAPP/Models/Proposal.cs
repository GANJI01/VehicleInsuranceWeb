using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Proposal
    {
        [RegularExpression(@"\w{10}", ErrorMessage = "Proposal No must be 10 characters")]
        public string ProposalNo { get; set; } = null!;
        [RegularExpression(@"\w{10}", ErrorMessage = "RegNo must be 10 characters")]
        public string RegNo { get; set; } = null!;
        [RegularExpression(@"\w{10}", ErrorMessage = "Product Id must be 10 characters")]
        public string ProductID { get; set; } = null!;
        [RegularExpression(@"\w{10}", ErrorMessage = "Customer Id must be 10 characters")]
        public string CustomerID { get; set; } = null!;
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public decimal IDV { get; set; }
        [RegularExpression(@"\w{10}", ErrorMessage = "Agent Id must be 10 characters")]
        public string AgentID { get; set; } = null!;
        [Required]
        public decimal? BasicAmount { get; set; }
        [Required]
        public decimal? TotalAmount { get; set; }
    }
}
