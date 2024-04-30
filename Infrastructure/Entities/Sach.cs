using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Sach
    {
        public Sach()
        {
            ChiTietPhieuMuons = new HashSet<ChiTietPhieuMuon>();
        }

        public string MaSach { get; set; } = null!;
        public string? TenSach { get; set; }
        public string? MaDmsach { get; set; }
        public string? MaTheLoai { get; set; }
        public string? TacGia { get; set; }
        public string? Nxb { get; set; }
        public int? NamXuatBan { get; set; }
        public int? SoLuongCon { get; set; }
        public string? TomTatNd { get; set; }

        public virtual DanhMucSach? MaDmsachNavigation { get; set; }
        public virtual TheLoai? MaTheLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
    }
}
