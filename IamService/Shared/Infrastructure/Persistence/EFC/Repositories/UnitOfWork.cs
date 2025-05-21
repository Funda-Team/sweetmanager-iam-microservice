using IamService.Shared.Domain.Repositories;
using IamService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace IamService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(IamContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}