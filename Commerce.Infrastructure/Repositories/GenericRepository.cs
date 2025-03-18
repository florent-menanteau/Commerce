using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T: class, IEntity
    {
        protected readonly CommerceDbContext commerceDbContext;

        public GenericRepository(CommerceDbContext commerceDbContext)
        {
            this.commerceDbContext = commerceDbContext;
        }
        public async Task<T?> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await commerceDbContext.Set<T>().FindAsync(id, cancellationToken);
        }
        public async Task<ICollection<T>?> GetListAsync(List<long> ids, CancellationToken cancellationToken)
        {
            return await commerceDbContext.Set<T>().Where(e => ids.Contains(e.Id.Value)).ToListAsync(cancellationToken);
        }
        public async Task<T?> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            commerceDbContext.Add(entity);
            if (await commerceDbContext.SaveChangesAsync(cancellationToken) != 0)
                return await GetAsync(entity.Id.Value, cancellationToken);
            return null;
        }


        public async Task<ICollection<T>?> CreateListAsync(ICollection<T> entity, CancellationToken cancellationToken)
        {
                await commerceDbContext.AddRangeAsync(entity);
            if (await commerceDbContext.SaveChangesAsync(cancellationToken) != 0)
                return await GetListAsync(entity.Select(e => e.Id.Value).ToList(), cancellationToken);
            return null;
        }

        public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            commerceDbContext.Update(entity!);
            return await commerceDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            commerceDbContext.Remove(entity!);
            return await commerceDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
