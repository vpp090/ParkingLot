namespace Domain
{
    public class Vehicle
    {
        public int Id {get; set;}
        public Category Category {get; set;}
        public string RegistrationNumber {get; set;}
        public bool VehicleInParking {get; set;}

        public DateTime VehicleEntryTime {get; set;}

        public Discount DiscountType {get; set;}
    }
}