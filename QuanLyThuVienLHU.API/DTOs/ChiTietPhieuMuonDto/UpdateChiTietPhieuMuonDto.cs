using QuanLyThuVienLHU.API.DTOs.Enum;

namespace QuanLyThuVienLHU.API.DTOs.ChiTietPhieuMuonDto
{
    public class UpdateChiTietPhieuMuonDto
    {
        public DateTime? NgayThucTra { get; set; }
        public decimal? TienPhat { get; set; }
        public string? TinhTrangSach { get; set; }
    }
}
