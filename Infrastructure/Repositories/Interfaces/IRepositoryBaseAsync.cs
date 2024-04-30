namespace Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryBaseAsync<T> where T : class
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
