using Domain;

namespace Application
{
    public class CalculatorAlgorithm : ICalculatorAlgorithm
    {
        public decimal CalculateCharges(Vehicle vehicle)
        {
            var tempDate = vehicle.VehicleEntryTime;
            decimal totalCharge = default;
         
            while(tempDate < DateTime.Now)
            {
                var hour = tempDate.Hour;
                if(hour > 8 && hour < 18)
                {
                    totalCharge += vehicle.Category.DailyChargePerHour;
                }
                else
                {
                    totalCharge += vehicle.Category.OvernightChargePerHour;
                }

                tempDate = tempDate.AddHours(1);
            }
            
            if(vehicle.DiscountType != null)
            {
                totalCharge = totalCharge - (totalCharge * ((decimal)vehicle.DiscountType.DiscountPercentage/100));
            }
            
            return totalCharge;
        }


    }
}