using Domain.Helper;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        IQueryable<T> All();
    }
}
