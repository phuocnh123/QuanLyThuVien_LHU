using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace infrastructure.repositories
{
    public interface ITaiKhoanRepository : IRepositoryBaseAsync<TaiKhoan>
    {

        Task<IEnumerable<TaiKhoan>> GetAllTaiKhoans();

        Task<TaiKhoan> GetTaiKhoanById(string taiKhoanId);

        Task<bool> CreateNewTaiKhoan(TaiKhoan taiKhoan);

        Task<bool> UpdateTaiKhoan(TaiKhoan taiKhoan);

        Task<bool> DeleteTaiKhoan(string taiKhoanId);
    }
    public class TaiKhoanRepository : RepositoryBaseAsync<TaiKhoan>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(QuanLyThuVien_LHUContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public async Task<IEnumerable<TaiKhoan>> GetAllTaiKhoans() => await GetAll();

        public async Task<TaiKhoan> GetTaiKhoanById(string taiKhoanId)
        {
            if (taiKhoanId != null)
            {
                var taiKhoan = await this.GetById(taiKhoanId);
                if (taiKhoan != null) return taiKhoan;
            }
            return null;
        }

        public async Task<bool> CreateNewTaiKhoan(TaiKhoan taiKhoan)
        {
            if (taiKhoan != null)
            {
                await this.Add(taiKhoan);
                var result = await this.SaveChangesAsync();

                if (result > 0) return true;
            }
            return false;
        }    

        public async Task<bool> UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            if (taiKhoan != null)
            {
                this.Update(taiKhoan);
                var result = await this.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
        public async Task<bool> DeleteTaiKhoan(string taiKhoanId)
        {
            var taiKhoan = await GetTaiKhoanById(taiKhoanId);
            if (taiKhoan != null)
            {
                this.Delete(taiKhoan);
                var result = await SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
