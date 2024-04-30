using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class PhieuMuon
    {
        public PhieuMuon()
        {
            ChiTietPhieuMuons = new HashSet<ChiTietPhieuMuon>();
        }

        public string MaPhieuMuon { get; set; } = null!;
        public DateTime? NgayMuon { get; set; }
        public int? SoNgayMuon { get; set; }
        public string? MaTaiKhoan { get; set; }
        public string? MaNhanVien { get; set; }
        public string? GhiChu { get; set; }
        public string? TrangThai { get; set; }

        public virtual NhanVien? MaNhanVienNavigation { get; set; }
        public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
    }
}
