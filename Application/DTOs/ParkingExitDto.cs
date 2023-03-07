namespace Application.DTOs
{
    public class ParkingExitDto
    {
        public string RegistrationNumber { get; set; }
        public decimal TotalCharge {get; set;}    

        public bool VehicleExited {get; set;}    
    }
}