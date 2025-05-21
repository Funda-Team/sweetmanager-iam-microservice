using IamService.Shared.Domain.Repositories;

namespace IamService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(IAMContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}