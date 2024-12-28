using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class QueryResponse
    {
        [RegularExpression(@"\w[10]", ErrorMessage = "Query Id must be 10 characters")]
        public string QueryID { get; set; } = null!;
        [RegularExpression(@"\w[10]", ErrorMessage = "SrNo must be 10 characters")]
        public string SrNo { get; set; } = null!;
        [RegularExpression(@"\w[10]", ErrorMessage = "Agent Id must be 10 characters")]
        public string? AgentID { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public DateTime ResponseDate { get; set; }
    }
}
