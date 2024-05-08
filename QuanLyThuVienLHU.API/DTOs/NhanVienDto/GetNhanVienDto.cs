namespace QuanLyThuVienLHU.API.DTOs.NhanVienDto
{
    public class GetNhanVienDto
    {
        public string MaNhanVien { get; set; } = null!;
        public string? TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public string? Sdt { get; set; }
    }
}
