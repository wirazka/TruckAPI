

namespace TruckAPI.ViewModels
{
    public class CommonResponseViewModel
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public CommonResponseViewModel() {
            Success = true;
        }

        public void ReportError(string error) 
        { 
            Success = false;
            Error = error;
        }
    }
}
