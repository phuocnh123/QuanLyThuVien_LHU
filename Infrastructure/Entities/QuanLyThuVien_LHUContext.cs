using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Entities
{
    public partial class QuanLyThuVien_LHUContext : DbContext
    {
        public QuanLyThuVien_LHUContext()
        {
        }

        public QuanLyThuVien_LHUContext(DbContextOptions<QuanLyThuVien_LHUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = null!;
        public virtual DbSet<DanhMucSach> DanhMucSaches { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; } = null!;
        public virtual DbSet<Sach> Saches { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<TheLoai> TheLoais { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QuanLyThuVien_LHU;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietPhieuMuon>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuMuon, e.MaSach })
                    .HasName("PK__ChiTietP__0FEB7560FABE8451");

                entity.ToTable("ChiTietPhieuMuon");

                entity.Property(e => e.MaPhieuMuon)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MaSach)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NgayThucTra).HasColumnType("date");

                entity.Property(e => e.TienPhat).HasColumnType("money");

                entity.Property(e => e.TinhTrangSach).HasMaxLength(100);

                entity.HasOne(d => d.MaPhieuMuonNavigation)
                    .WithMany(p => p.ChiTietPhieuMuons)
                    .HasForeignKey(d => d.MaPhieuMuon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPh__MaPhi__4CA06362");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.ChiTietPhieuMuons)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPh__MaSac__4D94879B");
            });

            modelBuilder.Entity<DanhMucSach>(entity =>
            {
                entity.HasKey(e => e.MaDmsach)
                    .HasName("PK__DanhMucS__FD4E35FB5C3C8B8D");

                entity.ToTable("DanhMucSach");

                entity.Property(e => e.MaDmsach)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaDMSach")
                    .IsFixedLength();

                entity.Property(e => e.TenDmsach)
                    .HasMaxLength(100)
                    .HasColumnName("TenDMSach");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA470AA320B6");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Status).HasDefaultValueSql("('1')");

                entity.Property(e => e.TenNhanVien).HasMaxLength(100);
            });

            modelBuilder.Entity<PhieuMuon>(entity =>
            {
                entity.HasKey(e => e.MaPhieuMuon)
                    .HasName("PK__PhieuMuo__C4C8222297BCE95B");

                entity.ToTable("PhieuMuon");

                entity.Property(e => e.MaPhieuMuon)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaTaiKhoan)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayMuon).HasColumnType("date");

                entity.Property(e => e.TrangThai).HasMaxLength(100);

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.PhieuMuons)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__PhieuMuon__MaNha__4E88ABD4");

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.PhieuMuons)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .HasConstraintName("FK__PhieuMuon__MaTai__4F7CD00D");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__Sach__B235742DFF10D99E");

                entity.ToTable("Sach");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MaDmsach)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaDMSach")
                    .IsFixedLength();

                entity.Property(e => e.MaTheLoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nxb)
                    .HasMaxLength(100)
                    .HasColumnName("NXB");

                entity.Property(e => e.TacGia).HasMaxLength(100);

                entity.Property(e => e.TenSach).HasMaxLength(100);

                entity.Property(e => e.TomTatNd)
                    .HasColumnType("ntext")
                    .HasColumnName("TomTatND");

                entity.HasOne(d => d.MaDmsachNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaDmsach)
                    .HasConstraintName("FK__Sach__MaDMSach__5070F446");

                entity.HasOne(d => d.MaTheLoaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaTheLoai)
                    .HasConstraintName("FK__Sach__MaTheLoai__5165187F");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoan)
                    .HasName("PK__TaiKhoan__AD7C652940D777B3");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaTaiKhoan)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.SoLuongMuon).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("('1')");

                entity.Property(e => e.TenNguoiDung).HasMaxLength(100);
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTheLoai)
                    .HasName("PK__TheLoai__D73FF34A281B8E0E");

                entity.ToTable("TheLoai");

                entity.Property(e => e.MaTheLoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenTheLoai).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
