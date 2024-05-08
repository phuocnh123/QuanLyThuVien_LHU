namespace QuanLyThuVienLHU.API.DTOs.TaiKhoanDto
{
    public class GetTaiKhoanDto : UpdateTaiKhoanDto
    {
        public string MaTaiKhoan { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? SoLuongMuon { get; set; }
    }
}
