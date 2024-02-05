using Domain.Enums;
using Domain.Models;

namespace TruckAPI.ViewModels
{
    public class AddUpdateTruckRequestViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TruckStatus TruckStatus { get; set; }
        public string Description { get; set; }

        public Truck MapToTruck() => new Truck 
        { 
            Code = Code,
            Name = Name,
            TruckStatus = TruckStatus,
            Description = Description
        };
        
    }
}
