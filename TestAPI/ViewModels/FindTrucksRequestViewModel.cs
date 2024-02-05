using Domain.Enums;
using TruckAPI.Enums;

namespace TruckAPI.ViewModels
{
    public class FindTrucksRequestViewModel
    {
        public FindTrucksRequestViewModel() {
            Filter = new FindTrucksFilterRequestViewModel();
            Sort = new FindTrucksSortRequestViewModel();
        }
        public FindTrucksFilterRequestViewModel Filter { get; set; }
        public FindTrucksSortRequestViewModel Sort { get; set; }
    }

    public class FindTrucksFilterRequestViewModel
    {
        public string? Name { get; set; }
        public TruckStatus? TruckStatus { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDateFrom { get; set; }
        public DateTime? CreateDateTo { get; set; }
        public DateTime? ModificationDateFrom { get; set; }
        public DateTime? ModificationDateTo { get; set; }
    }

    public class FindTrucksSortRequestViewModel
    {
        public TruckSortField? Field { get; set; }
        public TruckSortOrder? Order { get; set; }
    }
}
