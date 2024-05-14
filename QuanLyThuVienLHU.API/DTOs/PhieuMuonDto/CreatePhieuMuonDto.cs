using Infrastructure.Entities;

namespace QuanLyThuVienLHU.API.DTOs.PhieuMuonDto
{
    public class CreatePhieuMuonDto
    {
        public string MaPhieuMuon { get; set; } = null!;
        public DateTime? NgayMuon { get; set; } = DateTime.Now;
        public int? SoNgayMuon { get; set; }
        public string? MaTaiKhoan { get; set; }
        public string? MaNhanVien { get; set; }
        public string? GhiChu { get; set; }
        public string? TrangThai { get; set; } = "Chưa trả";
        public List<MuonSachInfoDto> DsSachsMuon { get; set; }
    }
}
