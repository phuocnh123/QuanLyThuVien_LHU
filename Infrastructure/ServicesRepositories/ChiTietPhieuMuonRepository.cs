using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ServicesRepositories
{
    public interface IChiTietPhieuMuonRepository : IRepositoryBaseAsync<ChiTietPhieuMuon>
    {
        Task<ChiTietPhieuMuon> GetChiTietPhieuMuonById(string phieuMuonId, string maSach);
        Task<bool> UpdateChiTietPhieuMuon(ChiTietPhieuMuon chiTietPhieuMuon);
        Task<bool> CreateNewPhieuMuon(ChiTietPhieuMuon ctPhieuMuon);
    }
    public class ChiTietPhieuMuonRepository : RepositoryBaseAsync<ChiTietPhieuMuon>, IChiTietPhieuMuonRepository
    {
        private readonly QuanLyThuVien_LHUContext _context;
        public ChiTietPhieuMuonRepository(QuanLyThuVien_LHUContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
        }

        public async Task<ChiTietPhieuMuon> GetChiTietPhieuMuonById(string phieuMuonId, string maSach)
        {
            if (phieuMuonId != null && maSach != null)
            {
                var chiTietPhieuMuon = await _context.Set<ChiTietPhieuMuon>()
                    .FirstOrDefaultAsync(ctpm => ctpm.MaPhieuMuon == phieuMuonId && ctpm.MaSach == maSach);
                return chiTietPhieuMuon;
            }
            return null;
        }


        public async Task<bool> UpdateChiTietPhieuMuon(ChiTietPhieuMuon chiTietPhieuMuon)
        {
            if (chiTietPhieuMuon != null)
            {
                this.Update(chiTietPhieuMuon);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateNewPhieuMuon(ChiTietPhieuMuon ctPhieuMuon)
        {
            if (ctPhieuMuon.MaPhieuMuon != null && ctPhieuMuon.MaSach != null)
            {
                await this.Add(ctPhieuMuon);
                return true;
            }
            return false;
        }
    }
}
