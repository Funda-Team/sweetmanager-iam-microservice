namespace IamService.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
