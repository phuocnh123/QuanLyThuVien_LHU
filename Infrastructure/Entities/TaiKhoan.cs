using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            PhieuMuons = new HashSet<PhieuMuon>();
        }

        public string MaTaiKhoan { get; set; } = null!;
        public string? MatKhau { get; set; }
        public string? TenNguoiDung { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public int? Status { get; set; }
        public int? SoLuongMuon { get; set; }

        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
    }
}
