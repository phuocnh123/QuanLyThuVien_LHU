using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ServicesRepositories
{
    public interface IPhieuMuonRepository : IRepositoryBaseAsync<PhieuMuon>
    {
        Task<PhieuMuon> GetPhieuMuonById(string phieuMuonId);

        Task<List<PhieuMuon>> GetPhieuMuonByMaTK(string maTaiKhoan);
        Task<bool> CreateNewPhieuMuon(PhieuMuon phieuMuon);
    }
    public class PhieuMuonRepository : RepositoryBaseAsync<PhieuMuon>, IPhieuMuonRepository
    {
        private readonly QuanLyThuVien_LHUContext _context;
        public PhieuMuonRepository(QuanLyThuVien_LHUContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
        }

        public async Task<PhieuMuon> GetPhieuMuonById(string phieuMuonId)
        {
            if (phieuMuonId != null)
            {
                var phieuMuon = await this.GetById(phieuMuonId);
                if (phieuMuon != null) return phieuMuon;
            }
            return null;
        }

        public async Task<List<PhieuMuon>> GetPhieuMuonByMaTK(string maTaiKhoan)
        {
            if (maTaiKhoan != null)
            {
                List<PhieuMuon> phieuMuon = await _context.PhieuMuons.Where(o => o.MaTaiKhoan ==  maTaiKhoan).ToListAsync(); ;
                if (phieuMuon != null) return phieuMuon;
            }
            return null;
        }

        public async Task<bool> CreateNewPhieuMuon(PhieuMuon phieuMuon)
        {
            if(phieuMuon != null)
            {
                await this.Add(phieuMuon);
                var result = await this.SaveChangesAsync();
                if (result > 0) return true; 
            }
            return false;
        }
    }
}
