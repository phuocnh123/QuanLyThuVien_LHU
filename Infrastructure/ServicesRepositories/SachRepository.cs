using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public interface ISachRepository : IRepositoryBaseAsync<Sach>
    {

        Task<IEnumerable<Sach>> GetAllSachs();

        Task<Sach> GetSachById(string sachId);

        Task<bool> CreateNewSach(Sach sach);

        Task<bool> UpdateSach(Sach sach);

        Task<bool> DeleteSach(string sachId);
    }
    public class SachRepository : RepositoryBaseAsync<Sach>, ISachRepository
    {
        public SachRepository(QuanLyThuVien_LHUContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public async Task<IEnumerable<Sach>> GetAllSachs() => await GetAll();

        public async Task<Sach> GetSachById(string sachId)
        {
            if (sachId != null)
            {
                var sach = await this.GetById(sachId);
                if (sach != null) return sach;
            }
            return null;
        }

        public async Task<bool> CreateNewSach(Sach sach)
        {
            if (sach != null)
            {
                await this.Add(sach);
                var result = await this.SaveChangesAsync();

                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> UpdateSach(Sach sach)
        {
            if (sach != null)
            {
                this.Update(sach);
                var result = await this.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
        public async Task<bool> DeleteSach(string sachId)
        {
            var sach = await GetSachById(sachId);
            if (sach != null)
            {
                this.Delete(sach);
                var result = await SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
