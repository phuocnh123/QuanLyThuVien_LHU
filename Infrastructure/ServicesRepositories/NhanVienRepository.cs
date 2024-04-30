using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public interface INhanVienRepository : IRepositoryBaseAsync<NhanVien>
    {

        Task<IEnumerable<NhanVien>> GetAllNhanViens();

        Task<NhanVien> GetNhanVienById(string nhanVienId);

        Task<bool> CreateNewNhanVien(NhanVien nhanVien);

        Task<bool> UpdateNhanVien(NhanVien nhanVien);

        Task<bool> DeleteNhanVien(string nhanVienId);
    }
    public class NhanVienRepository : RepositoryBaseAsync<NhanVien>, INhanVienRepository
    {
        public NhanVienRepository(QuanLyThuVien_LHUContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public async Task<IEnumerable<NhanVien>> GetAllNhanViens() => await GetAll();
        public async Task<NhanVien> GetNhanVienById(string nhanVienId)
        {
            if (nhanVienId != null)
            {
                var nhanVien = await this.GetById(nhanVienId);
                if (nhanVien != null) return nhanVien;
            }
            return null;
        }

        public async Task<bool> CreateNewNhanVien(NhanVien nhanVien)
        {
            if (nhanVien != null)
            {
                await this.Add(nhanVien);
                var result = await this.SaveChangesAsync();

                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> UpdateNhanVien(NhanVien nhanVien)
        {
            if (nhanVien != null)
            {
                this.Update(nhanVien);
                var result = await this.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> DeleteNhanVien(string nhanVienId)
        {
            var nhanVien = await GetNhanVienById(nhanVienId);
            if(nhanVien != null)
            {
                this.Delete(nhanVien); 
                var result = await SaveChangesAsync();
                if(result > 0) return true;
            }
            return false;
        }     
    }
}
