

namespace Application.DTOs
{
    public class VehicleDto
    {
        public string RegistrationNumber { get; set; }
        public DateTime DateEntry {get; set;}
        public decimal TotalCharge {get; set;}
        public decimal TotalDiscount {get; set;}
    }
}