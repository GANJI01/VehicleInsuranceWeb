namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class CustomerQuery
    {
        public string QueryID { get; set; } = null!;

        public string? CustomerID { get; set; }

        public string Description { get; set; } = null!;

        public DateTime? QueryDate { get; set; }

        public string Status { get; set; } = null!;
    }
}
