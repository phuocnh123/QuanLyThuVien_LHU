namespace QuanLyThuVienLHU.API.DTOs.TaiKhoanDto
{
    public class CreateTaiKhoanDto
    {
        public string MaTaiKhoan { get; set; } = null!;
        public string? MatKhau { get; set; }
        public string? TenNguoiDung { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public string? Email { get; set; }
    }
}
