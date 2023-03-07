

using Domain;

namespace Application.DTOs
{
    public class ParkingEntryDto
    {
        public string RegistrationNumber {get; set;}
        public CategoryType Category {get; set;}
        public DiscountType? Discount {get; set;}
    }
}