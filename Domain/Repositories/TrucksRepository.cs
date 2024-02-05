using Domain.Context;
using Domain.Enums;
using Domain.Helper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Repositories
{
    public class TrucksRepository : BaseRepository<Truck>, ITrucksRepository
    {
        public TrucksRepository(TestContext dbContext) : base(dbContext)
        {
        }

        public async Task<Truck> GetTruckAsync(string code) => await All().FirstOrDefaultAsync(x => x.Code == code);

        public IQueryable<Truck> GetAll() => All();

        public async Task<RepoState> AddTruckAsync(Truck truck)
        {
            var state = new RepoState();

            if (await GetAll().AnyAsync(t => t.Code == truck.Code))
            {
                state.AddError("The truck cannot be added because another one with the same code already exists.");
                return state;
            }

            truck.CreateDate = DateTime.Now;
            truck.ModificationDate = DateTime.Now;

            await InsertAsync(truck);

            return state;
        }

        public async Task<RepoState> DeleteTruckAsync(string code)
        {
            var state = new RepoState();

            var truck = await GetTruckAsync(code);

            if (truck == null)
            {
                state.AddError("The truck cannot be deleted because it was not found in the database.");
                return state;
            }

            await DeleteAsync(truck);

            return state;
        }

        public async Task<RepoState> UpdateTruckAsync(Truck truck)
        {
            var state = new RepoState();

            var truckDb = await GetTruckAsync(truck.Code);

            if (truckDb == null)
            {
                state.AddError("The truck cannot be modified because it was not found in the database.");
                return state;
            }

            if (truckDb.TruckStatus != TruckStatus.OutOfService && truck.TruckStatus != TruckStatus.OutOfService) 
            {
                bool validStatus;

                switch (truck.TruckStatus) 
                { 
                    case TruckStatus.Loading:
                        validStatus = truckDb.TruckStatus == TruckStatus.Returning;
                        break;
                    case TruckStatus.ToJob:
                        validStatus = truckDb.TruckStatus == TruckStatus.Loading;
                        break;
                    case TruckStatus.AtJob:
                        validStatus = truckDb.TruckStatus == TruckStatus.ToJob;
                        break;
                    case TruckStatus.Returning:
                        validStatus = truckDb.TruckStatus == TruckStatus.AtJob;
                        break;
                    default:
                        validStatus = false;
                        break;
                }

                if (!validStatus)
                {
                    state.AddError($"The truck cannot be modified because the status '{truckDb.TruckStatus.GetEnumDisplayName()}' cannot be changed to '{truck.TruckStatus.GetEnumDisplayName()}'.");
                    return state;
                }
            }

            truckDb.Name = truck.Name;
            truckDb.TruckStatus = truck.TruckStatus;
            truckDb.Description = truck.Description;

            truckDb.ModificationDate = DateTime.Now;

            await context.SaveChangesAsync();

            return state;
        }
    }
}
