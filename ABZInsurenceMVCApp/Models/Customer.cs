namespace ABZInsurenceMVCApp.Models
{
    public class Customer
    {
        public string CustomerID { get; set; } = null!;

        public string CustomerName { get; set; } = null!;

        public string CustomerPhone { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public string? CustomerAddress { get; set; }
    }
}
