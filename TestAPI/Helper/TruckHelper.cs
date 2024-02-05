using Domain.Models;
using System.Linq.Expressions;
using TruckAPI.Enums;
using TruckAPI.ViewModels;

namespace TruckAPI.Helper
{
    public static class TruckHelper
    {
        /// <summary>
        /// Function prepares where expression and sort for database based on given parameters
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IQueryable<Truck> FindAndSort(this IQueryable<Truck> truck, FindTrucksRequestViewModel search) {

            var model = search.Filter;

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                truck = truck.Where(t => t.Name.Contains(model.Name));
            }

            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                truck = truck.Where(t => t.Description.Contains(model.Description));
            }

            if (model.TruckStatus.HasValue)
            {
                truck = truck.Where(t => t.TruckStatus == model.TruckStatus.Value);
            }

            if (model.CreateDateTo.HasValue)
            {
                truck = truck.Where(t => t.CreateDate <= model.CreateDateTo.Value);
            }

            if (model.CreateDateFrom.HasValue)
            {
                truck = truck.Where(t => t.CreateDate >= model.CreateDateFrom.Value);
            }

            if (model.ModificationDateTo.HasValue)
            {
                truck = truck.Where(t => t.ModificationDate <= model.ModificationDateTo.Value);
            }

            if (model.ModificationDateFrom.HasValue)
            {
                truck = truck.Where(t => t.ModificationDate >= model.ModificationDateFrom.Value);
            }

            var order = search.Sort?.Order;

            switch (search.Sort?.Field)
            {
                case TruckSortField.Code:
                default:
                    truck = truck.Sort(order, t => t.Code);
                    break;
                case TruckSortField.Name:
                    truck = truck.Sort(order, t => t.Name);
                    break;
                case TruckSortField.TruckStatus:
                    truck = truck.Sort(order, t => t.TruckStatus);
                    break;
                case TruckSortField.Description:
                    truck = truck.Sort(order, t => t.Description);
                    break;
                case TruckSortField.CreateDate:
                    truck = truck.Sort(order, t => t.CreateDate);
                    break;
                case TruckSortField.ModificationDate:
                    truck = truck.Sort(order, t => t.ModificationDate);
                    break;
            }
            return truck;
        }

        /// <summary>
        /// Map Truck model to Turck view model
        /// </summary>
        /// <param name="truck"></param>
        /// <returns></returns>
        public static TruckViewModel MapToTruckVM(this Truck truck) => 
            new TruckViewModel
            { 
                Id = truck.Id,
                Code = truck.Code,
                Name = truck.Name,
                TruckStatus = truck.TruckStatus,
                Description = truck.Description,
                CreateDate = truck.CreateDate,
                ModificationDate = truck.ModificationDate
            };

        private static IQueryable<TSource> Sort<TSource, TKey>(this IQueryable<TSource> trucks, TruckSortOrder? order, Expression<Func<TSource, TKey>> selector) 
        {
            if (order == TruckSortOrder.DESC)
                trucks = trucks.OrderByDescending(selector);
            else
                trucks = trucks.OrderBy(selector);
            return trucks;
        }


    }
}
