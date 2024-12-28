using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Policy
    {
        [RegularExpression(@"\w[10]", ErrorMessage = "Policy No must be 10 Characters")]
        public string PolicyNo { get; set; } = null!;
        [RegularExpression(@"\w[10]", ErrorMessage = "Proposal No must be 10 characters")]
        public string? ProposalNo { get; set; }
        [Required]
        public decimal? NoClaimBonus { get; set; }
        [RegularExpression(@"\w[5]", ErrorMessage = "ReceiptNo must be 5 Characters")]
        public string ReceiptNo { get; set; } = null!;

        [Required]
        public DateTime ReceiptDate { get; set; }
        [RegularExpression(@"\w[1]", ErrorMessage = "Payment Mode must be C/Q/U/D")]
        public string PaymentMode { get; set; } = null!;
        [Required]
        public decimal? Amount { get; set; }
    }
}
