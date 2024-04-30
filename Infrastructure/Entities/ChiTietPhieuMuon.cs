using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class ChiTietPhieuMuon
    {
        public string MaPhieuMuon { get; set; } = null!;
        public string MaSach { get; set; } = null!;
        public DateTime? NgayThucTra { get; set; }
        public decimal? TienPhat { get; set; }
        public string? TinhTrangSach { get; set; }

        public virtual PhieuMuon MaPhieuMuonNavigation { get; set; } = null!;
        public virtual Sach MaSachNavigation { get; set; } = null!;
    }
}
