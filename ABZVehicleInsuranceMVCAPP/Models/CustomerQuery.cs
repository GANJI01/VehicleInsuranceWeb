using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class CustomerQuery
    {
        [RegularExpression(@"\w[10]", ErrorMessage = "QueryID must be 10 Characters")]
        public string QueryID { get; set; } = null!;
        [RegularExpression(@"\w[10]", ErrorMessage = "CustomerID must be 10 Characters")]
        public string? CustomerID { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public DateTime? QueryDate { get; set; }
        [RegularExpression(@"\w[1]", ErrorMessage = "Status should be A/R")]
        public string Status { get; set; } = null!;
    }
}
