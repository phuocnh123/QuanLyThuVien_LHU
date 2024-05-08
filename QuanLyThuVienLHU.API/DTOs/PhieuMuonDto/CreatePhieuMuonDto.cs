using Infrastructure.Entities;

namespace QuanLyThuVienLHU.API.DTOs.PhieuMuonDto
{
    public class CreatePhieuMuonDto
    {
        public string MaPhieuMuon { get; set; } = null!;
        public int? SoNgayMuon { get; set; }
        public string? MaTaiKhoan { get; set; }
        public string? MaNhanVien { get; set; }
        public string? GhiChu { get; set; }
        public List<MuonSachInfoDto> DsSachsMuon { get; set; }
    }
}
