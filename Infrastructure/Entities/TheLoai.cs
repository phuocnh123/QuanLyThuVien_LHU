using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaTheLoai { get; set; } = null!;
        public string? TenTheLoai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
