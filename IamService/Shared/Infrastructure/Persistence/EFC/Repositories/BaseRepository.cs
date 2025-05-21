using IamService.Shared.Domain.Repositories;

namespace IamService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository<TEntity>(IAMContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IAMContext Context = context;

        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
    }
}