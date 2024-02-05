using Domain.Context;
using Domain.Enums;
using Domain.Helper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel
    {
        protected TestContext context;

        public TestContext Context
        {
            get { return context; }
        }

        public BaseRepository(TestContext context)
        {
            this.context = context;
        }

        public void Insert(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public async Task InsertAsync(T item)
        {
            await context.Set<T>().AddAsync(item);
            await context.SaveChangesAsync();
        }

        public void Update(T item)
        {
            context.Set<T>().Attach(item);
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            context.Set<T>().Attach(item);
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public async Task DeleteAsync(T item)
        {
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }

        public IQueryable<T> All()
        {
            return context.Set<T>();
        }
    }
}
