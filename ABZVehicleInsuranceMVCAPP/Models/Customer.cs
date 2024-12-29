using System.ComponentModel.DataAnnotations;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class Customer
    {
        [RegularExpression(@"\w{10}", ErrorMessage = "Customer ID must be 10 Characters")]
        public string CustomerID { get; set; } = null!;
        [Required]
        public string CustomerName { get; set; } = null!;
        [RegularExpression(@"\d{10}", ErrorMessage = "Customer Phone must be 10 digit")]
        public string CustomerPhone { get; set; } = null!;
        [Required]
        public string CustomerEmail { get; set; } = null!;
        [Required]
        public string? CustomerAddress { get; set; }
    }
}
