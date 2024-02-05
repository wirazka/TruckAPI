namespace TruckAPI.ViewModels
{
    public class GetTrucksResponseViewModel
    {
        public CommonResponseViewModel Response { get; set; }
        public IReadOnlyList<TruckViewModel> Trucks { get; set; }

        public GetTrucksResponseViewModel() 
        {
            Response = new CommonResponseViewModel();
        }
    }
}
