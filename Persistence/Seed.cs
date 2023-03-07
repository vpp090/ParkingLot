using Domain;

namespace Persistence
{
    public class Seed
    {

        public static async Task SeedData(DataContext context)
        {
            if(context.ParkingLot.Any()) return;

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryType = CategoryType.A,
                    DailyChargePerHour = 3,
                    OvernightChargePerHour = 2,
                    SpacesUsed = 1
                },
                new Category
                {
                    CategoryType = CategoryType.B,
                    SpacesUsed = 2,
                    DailyChargePerHour = 6,
                    OvernightChargePerHour = 4
                },
                new Category
                {
                    CategoryType = CategoryType.C,
                    DailyChargePerHour = 12,
                    OvernightChargePerHour = 8,
                    SpacesUsed = 4
                } 
            };
            await context.Categories.AddRangeAsync(categories);

            var discounts = new List<Discount>
            {
                new Discount
                {
                    DiscountType = DiscountType.Silver,
                    DiscountPercentage = 10
                },
                new Discount
                {
                    DiscountType = DiscountType.Gold,
                    DiscountPercentage = 15
                },
                new Discount
                {
                    DiscountType = DiscountType.Platinum,
                    DiscountPercentage = 20
                }
            };

            await context.Discounts.AddRangeAsync(discounts);

            var vehicles = new List<Vehicle>()
            {
                new Vehicle
                {
                    RegistrationNumber = "b4422ca",
                    VehicleEntryTime = new DateTime(2023, 3, 3,12,45,12),
                    Category = categories[0]
                      
                },
                new Vehicle
                {
                    RegistrationNumber = "b5422ca",
                    VehicleEntryTime = new DateTime(2023, 3, 4,12,45,12),
                    Category = categories[1]
                },
                new Vehicle
                {
                    RegistrationNumber = "b6422ca",
                    VehicleEntryTime = new DateTime(2023, 3, 5,12,45,12),
                    Category = categories[2]
                }
            };
            
            var ParkingLot = new Domain.ParkingLot
            {
                Vehicles = vehicles,
                Capacity = 193       
            };

            await context.ParkingLot.AddAsync(ParkingLot);
            await context.SaveChangesAsync();
        }
    }
}