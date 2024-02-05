
namespace TruckAPI.ViewModels
{
    public class GetTruckResponseViewModel
    {
        public TruckViewModel Truck { get; set; }
        public CommonResponseViewModel Response { get; set; }

        public GetTruckResponseViewModel()
        {
            Response = new CommonResponseViewModel();
        }
    }
}
