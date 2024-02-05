using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckAPI.Helper;
using TruckAPI.ViewModels;

namespace TruckAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TrucksController : ControllerBase
    {
        private readonly ILogger<TrucksController> _logger;
        private readonly ITrucksRepository _trucksRepository;

        public TrucksController(ILogger<TrucksController> logger, ITrucksRepository trucksRepository)
        {
            _logger = logger;
            _trucksRepository = trucksRepository;
        }

        [HttpGet(Name = "GetTruck")]
        public async Task<GetTruckResponseViewModel> GetSingle([FromQuery] string code)
        {
            var response = new GetTruckResponseViewModel();

            var truck = await _trucksRepository.GetTruckAsync(code);

            if (truck == null)
            {
                response.Response.ReportError("The truck with the provided code was not found.");
            }
            else
            {
                response.Truck = truck.MapToTruckVM();
            }

            return response;
        }

        [HttpGet(Name = "GetTrucks")]
        public async Task<GetTrucksResponseViewModel> GetMultiple([FromQuery] FindTrucksRequestViewModel model)
        {
            var response = new GetTrucksResponseViewModel();

            var trucks = _trucksRepository.GetAll().FindAndSort(model);

            if (!await trucks.AnyAsync())
            {
                response.Response.ReportError("No truck was found with the provided parameters.");
            }
            else
            {
                response.Trucks = await trucks.Select(t => t.MapToTruckVM()).ToListAsync();
            }

            return response;
        }

        [HttpPost(Name = "AddTruck")]
        public async Task<CommonResponseViewModel> Add([FromQuery] AddUpdateTruckRequestViewModel model)
        {
            var response = new CommonResponseViewModel();

            var addState = await _trucksRepository.AddTruckAsync(model.MapToTruck());

            if (addState.HasError())
                response.ReportError(addState.GetErrorMessage());

            return response;
        }

        [HttpPut(Name = "UpdateTruck")]
        public async Task<CommonResponseViewModel> Update([FromQuery] AddUpdateTruckRequestViewModel model)
        {
            var response = new CommonResponseViewModel();

            var updateState = await _trucksRepository.UpdateTruckAsync(model.MapToTruck());

            if (updateState.HasError())
                response.ReportError(updateState.GetErrorMessage());

            return response;
        }

        [HttpDelete(Name = "DeleteTruck")]
        public async Task<CommonResponseViewModel> Delete([FromQuery] string code)
        {
            var response = new CommonResponseViewModel();

            var deleteState = await _trucksRepository.DeleteTruckAsync(code);

            if (deleteState.HasError())
                response.ReportError(deleteState.GetErrorMessage());

            return response;
        }
    }
}
