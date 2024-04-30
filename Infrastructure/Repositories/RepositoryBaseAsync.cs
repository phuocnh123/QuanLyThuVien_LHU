using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RepositoryBaseAsync<T> : IRepositoryBaseAsync<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly QuanLyThuVien_LHUContext _context;
        public RepositoryBaseAsync(QuanLyThuVien_LHUContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetById(string id) => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public Task<int> SaveChangesAsync() => _unitOfWork.CommitAsync();
    }
}
