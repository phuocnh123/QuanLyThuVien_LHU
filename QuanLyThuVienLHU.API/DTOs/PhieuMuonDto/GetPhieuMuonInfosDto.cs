namespace QuanLyThuVienLHU.API.DTOs.PhieuMuonDto
{
    public class GetPhieuMuonInfosDto
    {
        public string MaPhieuMuon { get; set; } = null!;
        public DateTime? NgayMuon { get; set; }
        public int? SoNgayMuon { get; set; }
        public string? MaNhanVien { get; set; }
        public string? GhiChu { get; set; }
        public string? TrangThai { get; set; }
    }
}
