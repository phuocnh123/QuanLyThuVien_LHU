using Infrastructure.Entities;
using Infrastructure.ServicesRepositories;
using QuanLyThuVienLHU.API.DTOs.ChiTietPhieuMuonDto;

namespace QuanLyThuVienLHU.API.Serivces
{
    public class ChiTietPhieuMuonService
    {
        private readonly IChiTietPhieuMuonRepository _chiTietPhieuMuonRepository;

        public ChiTietPhieuMuonService(IChiTietPhieuMuonRepository chiTietPhieuMuonRepository)
        {
            _chiTietPhieuMuonRepository = chiTietPhieuMuonRepository;
        }

        public async Task CreateChiTietPhieuMuon(CreateChiTietPhieuMuonDto phieuMuonDto)
        {
            var chiTietPhieuMuonEntity = await _chiTietPhieuMuonRepository.GetChiTietPhieuMuonById(phieuMuonDto.MaPhieuMuon, phieuMuonDto.MaSach);

            var newCTPhieuMuon = new ChiTietPhieuMuon
            {
                MaPhieuMuon = phieuMuonDto.MaPhieuMuon,
                MaSach = phieuMuonDto.MaSach,
            };
            await _chiTietPhieuMuonRepository.CreateNewPhieuMuon(newCTPhieuMuon);
            await _chiTietPhieuMuonRepository.SaveChangesAsync();
        }

    }
}
