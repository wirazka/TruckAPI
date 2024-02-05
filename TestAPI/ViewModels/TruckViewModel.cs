using Domain.Enums;

namespace TruckAPI.ViewModels
{
    public class TruckViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TruckStatus TruckStatus { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
