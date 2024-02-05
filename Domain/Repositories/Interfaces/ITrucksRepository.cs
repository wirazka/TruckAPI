using Domain.Helper;
using Domain.Models;

namespace Domain.Repositories
{
    public interface ITrucksRepository
    {
        /// <summary>
        /// Get single truck by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Truck> GetTruckAsync(string code);
        /// <summary>
        /// Return all trucks (query)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Truck> GetAll();
        /// <summary>
        /// Add new truck
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<RepoState> AddTruckAsync(Truck truck);
        /// <summary>
        /// Delete truck by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<RepoState> DeleteTruckAsync(string code);
        /// <summary>
        /// Update truck data
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<RepoState> UpdateTruckAsync(Truck truck);
    }
}
