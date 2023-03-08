
using Application;
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLot : ControllerBase
    {
        private readonly IParkingService _parkingService;
        public ParkingLot(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet("/getvehicle/{registrationNumber}")]
        public async Task<ActionResult<VehicleDto>> GetVehicle(string registrationNumber)
        {
            return await _parkingService.GetVehicle(registrationNumber);
        }

        [HttpGet("/getallvehicles")]
        public async Task<ActionResult<List<VehicleDto>>> GetAllVehicles()
        {
            return await _parkingService.GetAllVehicles();
        }

        [HttpGet("/availability")]
        public async Task<ActionResult<ServiceResponse<int>>> GetAvailableSpaces()
        {
            return await _parkingService.GetAvailableSpaces();
        }

        [HttpGet("/checkcharge/{registrationNumber}")]
        public async Task<ActionResult<ServiceResponse<decimal>>> CheckCharge(string registrationNumber)
        {
            return await _parkingService.CheckAccumulatedCharge(registrationNumber);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Vehicle>>> ParkingEntry(ParkingEntryDto entryDto)
        {
            return await _parkingService.ParkingEntry(entryDto);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<ParkingExitDto>>> ParkingExit(string registrationNumber)
        {
             return await _parkingService.ParkingExit(registrationNumber);
        }
    }
}