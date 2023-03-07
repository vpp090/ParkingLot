using Application.Common;
using Application.DTOs;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{
    public class ParkingService : IParkingService
    {
        private readonly DataContext _dataContext;
        private readonly ICalculatorAlgorithm _calculatorAlgorithm;

        public ParkingService(DataContext dataContext, ICalculatorAlgorithm algorithm)
        {
            _dataContext = dataContext;
            _calculatorAlgorithm = algorithm;
        }

        public async Task<ServiceResponse<int>> GetAvailableSpaces()
        {
            var parkingLot = await _dataContext.ParkingLot.FirstOrDefaultAsync();
            var response = new ServiceResponse<int>
            {
                Data = parkingLot.Capacity,
                Success = true
            };

            return response;
        }


        public async Task<ServiceResponse<decimal>> CheckAccumulatedCharge(string registrationNumber)
        {
            var selectedVehicle = await _dataContext.Vehicles.Include(v => v.Category).SingleOrDefaultAsync(v => v.RegistrationNumber == registrationNumber);

            var totalCharge = _calculatorAlgorithm.CalculateCharges(selectedVehicle);

            var response = new ServiceResponse<decimal>
            {
                Data = totalCharge,
                Success = true,
            };

            return response;
        }

        public async Task<ServiceResponse<Vehicle>> ParkingEntry(ParkingEntryDto entryDto)
        {
            var category = await _dataContext.Categories.SingleOrDefaultAsync(c => (int)c.CategoryType == (int)entryDto.Category);
            var discount = entryDto.Discount != null ? await _dataContext.Discounts.SingleOrDefaultAsync(d => (int)d.DiscountType == (int)entryDto.Discount) : null;
            var parkingLot = await _dataContext.ParkingLot.SingleOrDefaultAsync();

            var response = new ServiceResponse<Vehicle>();

            var checkVehicle = await _dataContext.Vehicles.SingleOrDefaultAsync(v => v.RegistrationNumber == entryDto.RegistrationNumber);

            if (checkVehicle != null)
            {
                response.Data = null;
                response.Success = false;
                response.ErrorMessage = ErrorMessages.RegistrationNumberAlreadyIn;
            }
            else if (parkingLot.Capacity <= 0)
            {
                response.Data = null;
                response.Success = false;
                response.ErrorMessage = ErrorMessages.CapacityFull;
            }
            else
            {
                var vehicle = new Vehicle
                {
                    RegistrationNumber = entryDto.RegistrationNumber,
                    VehicleEntryTime = DateTime.Now,
                    Category = category,
                    DiscountType = discount
                };

                parkingLot.Capacity -= category.SpacesUsed;
                await _dataContext.Vehicles.AddAsync(vehicle);
                await _dataContext.SaveChangesAsync();

                response.Data = vehicle;
                response.Success = true;
            }

            return response;
        }

        public async Task<ServiceResponse<ParkingExitDto>> ParkingExit(string registrationNumber)
        {
            var vehicle = await _dataContext.Vehicles.Include(v => v.Category).Include(v => v.DiscountType).SingleOrDefaultAsync();
            var totalCharge = _calculatorAlgorithm.CalculateCharges(vehicle);
            var parkingLot = await _dataContext.ParkingLot.SingleOrDefaultAsync();
            parkingLot.Capacity -= vehicle.Category.SpacesUsed;

            _dataContext.Vehicles.Remove(vehicle);

            var exitDto = new ParkingExitDto
            {
                RegistrationNumber = registrationNumber,
                TotalCharge = totalCharge,
                VehicleExited = true
            };

            var response = new ServiceResponse<ParkingExitDto>
            {
                Data = exitDto,
                Success = true
            };

            await _dataContext.SaveChangesAsync();

            return response;
        }
    }
}