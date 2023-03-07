using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ParkingLot
    {
        public int Id {get; set;}  
        public List<Vehicle> Vehicles {get; set;}
        [Range(0, 200, ErrorMessage = "Maximum number of spaces is 200") ]
        public int Capacity {get; set;}        
    }
}