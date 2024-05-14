namespace QuanLyThuVienLHU.API.DTOs.TaiKhoanDto
{
    public class GetTaiKhoanDto 
    {
        public string MaTaiKhoan { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? SoLuongMuon { get; set; }
        public string? TenNguoiDung { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
    }
}
