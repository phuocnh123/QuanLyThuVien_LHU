using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class DanhMucSach
    {
        public DanhMucSach()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaDmsach { get; set; } = null!;
        public string? TenDmsach { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
