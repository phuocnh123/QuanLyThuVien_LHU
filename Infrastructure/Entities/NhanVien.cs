using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            PhieuMuons = new HashSet<PhieuMuon>();
        }

        public string MaNhanVien { get; set; } = null!;
        public string? MatKhau { get; set; }
        public string? TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
    }
}
