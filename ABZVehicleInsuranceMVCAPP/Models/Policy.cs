namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Policy
    {
        public string PolicyNo { get; set; } = null!;

        public string? ProposalNo { get; set; }

        public decimal? NoClaimBonus { get; set; }

        public string ReceiptNo { get; set; } = null!;

        public DateTime ReceiptDate { get; set; }

        public string PaymentMode { get; set; } = null!;

        public decimal? Amount { get; set; }
    }
}
