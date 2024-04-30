using Infrastructure.Entities; 

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> CommitAsync();
    }
}
