using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuanLyThuVien_LHUContext _context;
        public UnitOfWork(QuanLyThuVien_LHUContext context)
        {
            _context = context;
        }
        public void Dispose() => _context.Dispose();
        public Task<int> CommitAsync() => _context.SaveChangesAsync();
    }
}
