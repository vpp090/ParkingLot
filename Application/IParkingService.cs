using Application.DTOs;
using Domain;

namespace Application
{
    public interface IParkingService
    {
        Task<ServiceResponse<int>> GetAvailableSpaces();
        Task<ServiceResponse<decimal>> CheckAccumulatedCharge(string registrationNumber);
        Task<ServiceResponse<Vehicle>> ParkingEntry(ParkingEntryDto vehicle);
        Task<ServiceResponse<ParkingExitDto>> ParkingExit(string registrationNumber);   
    }
}