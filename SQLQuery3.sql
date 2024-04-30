﻿﻿USE [master]
GO
/****** Object:  Database [QuanLyThuVien_LHU]    Script Date: 01/06/2021 8:37:00 PM ******/
CREATE DATABASE [QuanLyThuVien_LHU]
GO
USE [QuanLyThuVien_LHU]
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyThuVien_LHU].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET QUERY_STORE = OFF
GO
USE [QuanLyThuVien_LHU]
GO
/****** Object:  UserDefinedFunction [dbo].[func_nextID]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tự động tăng mã sách
create function [dbo].[func_nextID](@lastID varchar(5), @prefix varchar(2), @size int)
	returns varchar(5)
as
	BEGIN
		if(@lastID = '')
			set @lastID = @prefix + REPLICATE(0, @size - LEN(@prefix))
		declare @num_nextID int, @nextID varchar(5)
		set @lastID = LTRIM(RTRIM(@lastID))
		set @num_nextID = REPLACE(@lastID, @prefix, '') + 1
		set @size = @size - LEN(@prefix)
		set @nextID = @prefix + RIGHT(REPLICATE(0, @size) + CONVERT(VARCHAR(MAX), @num_nextID), @size)
		return  @nextID
	END
GO
/****** Object:  UserDefinedFunction [dbo].[tinhSoNgayTre]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[tinhSoNgayTre](@NgayMuon date, @ngayTra date, @SoNgayMuon int)
	returns int
as
	BEGIN
		declare @num int = (DAY(@ngayTra) - DAY(@NgayMuon)) - @SoNgayMuon
		return @num
	END
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](10) NOT NULL,
	[MatKhau] [varchar](20) NULL,
	[TenNhanVien] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [int] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](11) NULL,
	[Email] [varchar](100) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuMuon]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuMuon](
	[MaPhieuMuon] [varchar](5) NOT NULL,
	[MaSach] [varchar](5) NOT NULL,
	[NgayThucTra] [date] NULL,
	[TienPhat] [money] NULL,
	[TinhTrangSach] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSach]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSach](
	[MaDMSach] [varchar](10) NOT NULL,
	[TenDMSach] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDMSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[MaPhieuMuon] [varchar](5) NOT NULL,
	[NgayMuon] [date] NULL,
	[SoNgayMuon] [int] NULL,
	[MaTaiKhoan] [varchar](13) NULL,
	[MaNhanVien] [varchar](10) NULL,
	[GhiChu] [text] NULL,
	[TrangThai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [varchar](5) NOT NULL,
	[TenSach] [nvarchar](100) NULL,
	[MaDMSach] [varchar](10) NULL,
	[MaTheLoai] [varchar](10) NULL,
	[TacGia] [nvarchar](100) NULL,
	[NXB] [nvarchar](100) NULL,
	[NamXuatBan] [int] NULL,
	[SoLuongCon] [int] NULL,
	[TomTatND] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [varchar](13) NOT NULL,
	[MatKhau] [varchar](20) NULL,
	[TenNguoiDung] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [int] NULL,
	[Email] [varchar](100) NULL,
	[SDT] [varchar](11) NULL,
	[Status] [int] NULL,
	[SoLuongMuon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 01/06/2021 8:37:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [varchar](10) NOT NULL,
	[TenTheLoai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
create trigger tr_nextSach on dbo.Sach
for insert
as
	begin
		declare @lastSach varchar(5)
		set @lastSach = (Select top 1 MaSach from Sach order by MaSach desc)
		UPDATE Sach set MaSach = dbo.func_nextID(@lastSach, 'S', 5) where MaSach = ''
	end
GO
create trigger tr_nextMaPM on dbo.PhieuMuon
for insert
as
	begin
		declare @lastIdMaPM varchar(5)
		set @lastIdMaPM = (Select top 1 MaPhieuMuon from PhieuMuon order by MaPhieuMuon desc)
		UPDATE PhieuMuon set MaPhieuMuon = dbo.func_nextID(@lastIdMaPM, 'PM', 5) where MaPhieuMuon = ''
	end
go
--Trigger cập nhật Số lượng mượn
create trigger tr_SoLuongMuon on ChiTietPhieuMuon 
for insert 
as
	BEGIN
		update TaiKhoan
		set	SoLuongMuon = SoLuongMuon + 1
		from TaiKhoan, PhieuMuon, inserted
		where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon and TaiKhoan.MaTaiKhoan = PhieuMuon.MaTaiKhoan
	END
go

create trigger tr_SoLuongMuon_delete on ChiTietPhieuMuon 
for delete 
as
	BEGIN
		update TaiKhoan
		set	SoLuongMuon = SoLuongMuon - 1
		from TaiKhoan, PhieuMuon, inserted
		where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon and TaiKhoan.MaTaiKhoan = PhieuMuon.MaTaiKhoan
	END
go

--Trigger tính tiền phạt
create trigger tr_TienPhat on ChiTietPhieuMuon
for update
as
	begin 
		declare @NgayThucTra date = (select NgayThucTra from inserted)
		declare @NgayMuon date = (select NgayMuon from inserted, PhieuMuon where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon)
		declare @SoNgayMuon int = (select SoNgayMuon from inserted, PhieuMuon where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon)
		declare @tinhTrang nvarchar(100) = (select inserted.TinhTrangSach from inserted)
		
		if @tinhTrang = N'Bình thường'
			if (datediff(day, @NgayMuon, @NgayThucTra) > @SoNgayMuon)
				update ChiTietPhieuMuon
				set TienPhat = (datediff(Day, PhieuMuon.NgayMuon, inserted.NgayThucTra)) * 10000
				from inserted, PhieuMuon, ChiTietPhieuMuon
				where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon and ChiTietPhieuMuon.MaPhieuMuon = inserted.MaPhieuMuon
				and ChiTietPhieuMuon.MaSach = inserted.MaSach and PhieuMuon.MaPhieuMuon = ChiTietPhieuMuon.MaPhieuMuon
			else 
				update ChiTietPhieuMuon
				set TienPhat = 0
				from ChiTietPhieuMuon, inserted
				where ChiTietPhieuMuon.MaPhieuMuon = inserted.MaPhieuMuon
				and ChiTietPhieuMuon.MaSach = inserted.MaSach
		else if @tinhTrang = N'Mất sách'
			update ChiTietPhieuMuon
			set TienPhat = 50000
			from ChiTietPhieuMuon, inserted
			where ChiTietPhieuMuon.MaPhieuMuon = inserted.MaPhieuMuon
				and ChiTietPhieuMuon.MaSach = inserted.MaSach
		else if @tinhTrang = N'Hư hỏng'
			if ((datediff(day, @NgayMuon, @NgayThucTra)) > @SoNgayMuon)
				update ChiTietPhieuMuon
				set TienPhat = (datediff(Day, PhieuMuon.NgayMuon, inserted.NgayThucTra)) * 10000 + 20000
				from inserted, PhieuMuon, ChiTietPhieuMuon
				where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon and ChiTietPhieuMuon.MaPhieuMuon = inserted.MaPhieuMuon
				and ChiTietPhieuMuon.MaSach = inserted.MaSach and PhieuMuon.MaPhieuMuon = ChiTietPhieuMuon.MaPhieuMuon
			else
				update ChiTietPhieuMuon
				set TienPhat = 20000
				from ChiTietPhieuMuon, inserted
				where ChiTietPhieuMuon.MaPhieuMuon = inserted.MaPhieuMuon
				and ChiTietPhieuMuon.MaSach = inserted.MaSach
		--Cập nhật số lượng mượn
		if (@NgayThucTra is not null)
			update TaiKhoan
			set	SoLuongMuon = SoLuongMuon - 1
			from TaiKhoan, PhieuMuon, inserted
			where inserted.MaPhieuMuon = PhieuMuon.MaPhieuMuon and TaiKhoan.MaTaiKhoan = PhieuMuon.MaTaiKhoan
		else 
			return
	end
go

GO


INSERT [dbo].[NhanVien] ([MaNhanVien], [MatKhau], [TenNhanVien], [NgaySinh], [GioiTinh], [DiaChi], [SDT], [Email], [Status]) VALUES (N'101010', N'abc123', N'Trần Thị A', CAST(N'1990-07-02' AS Date), 1, N'02/Thanh Sơn', N'0773123889', N'tranthia@gmail.com', 1)
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM001', N'S0001', CAST(N'2021-05-27' AS Date), 50000.0000, N'Mất sách')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM001', N'S0002', CAST(N'2021-06-20' AS Date), 430000.0000, N'Hư hỏng')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM002', N'S0003', CAST(N'2021-06-20' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM002', N'S0004', NULL, 0.0000, N'')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM002', N'S0005', NULL, 0.0000, N'')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM003', N'S0006', NULL, 0.0000, N'')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM004', N'S0006', CAST(N'2021-05-27' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM004', N'S0008', CAST(N'2021-05-27' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM004', N'S0009', CAST(N'2021-05-27' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM005', N'S0006', CAST(N'2021-05-27' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM005', N'S0008', NULL, 0.0000, N'')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM006', N'S0002', CAST(N'2021-05-26' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM006', N'S0003', CAST(N'2021-05-26' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM006', N'S0007', CAST(N'2021-05-26' AS Date), 0.0000, N'Bình thường')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM007', N'S0003', NULL, 0.0000, N'')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM007', N'S0005', NULL, 0.0000, N'')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM008', N'S0007', CAST(N'2021-05-31' AS Date), 10000.0000, N'Trễ hạn')
INSERT [dbo].[ChiTietPhieuMuon] ([MaPhieuMuon], [MaSach], [NgayThucTra], [TienPhat], [TinhTrangSach]) VALUES (N'PM008', N'S0010', CAST(N'2021-05-31' AS Date), 10000.0000, N'Trễ hạn')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM001', N'Chuyên ngành Điện-Điện tử')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM002', N'Chuyên ngành Cơ khí')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM003', N'Chuyên ngành Công nghệ thông tin')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM004', N'Chuyên ngành Xây dựng')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM005', N'Sách Tiếng Anh')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM006', N'Kỹ năng sống')
INSERT [dbo].[DanhMucSach] ([MaDMSach], [TenDMSach]) VALUES (N'DM007', N'Sách nước ngoài')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM001', CAST(N'2021-05-10' AS Date), 7, N'1911505310132', N'101010', N'', N'Chưa trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM002', CAST(N'2021-05-11' AS Date), 7, N'1911505310118', N'101010', N'', N'Chưa trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM003', CAST(N'2021-05-12' AS Date), 14, N'1911505310123', N'101010', N'', N'Chưa trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM004', CAST(N'2021-05-24' AS Date), 7, N'1911505310132', N'101010', N'', N'Đã trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM005', CAST(N'2021-05-24' AS Date), 7, N'1911505310132', N'101010', N'', N'Chưa trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM006', CAST(N'2021-05-24' AS Date), 7, N'1911505310123', N'101010', N'', N'Đã trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM007', CAST(N'2021-05-25' AS Date), 7, N'1911505310132', N'101010', N'khong', N'Chưa trả')
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [NgayMuon], [SoNgayMuon], [MaTaiKhoan], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'PM008', CAST(N'2021-05-23' AS Date), 7, N'1911505310123', N'101010', N'', N'Chưa trả')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0001', N'Lập trình cơ bản với C', N'DM003', N'TL001', N'Hoàng Thị Mỹ Lệ', N'NXB Công nghệ thông tin', 2016, 5, N'Với mong muốn chia sẻ kinh nghiệm học lập trình và các kỹ năng mà anh đã trải qua trong suốt quá trình học và làm việc với tư cách là người đi trước cũng như là một Developer Full Stack, nên anh đã quyết định xuất bản sách')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0002', N'Giáo trình kỹ thuật xung số và ứng dụng', N'DM003', N'TL001', N'Nguyễn Linh Nam', N'NXB Công nghệ thông tin', 2016, 3, N'Với mong muốn chia sẻ kinh nghiệm học lập trình và các kỹ năng mà anh đã trải qua trong suốt quá trình học và làm việc với tư cách là người đi trước cũng như là một Developer Full Stack, nên anh đã quyết định xuất bản sách')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0003', N'Trường điện từ - Lý thuyết và bài tập', N'DM003', N'TL001', N'Lê Văn Sung', N'NXB Công nghệ thông tin', 2016, 3, N'Với mong muốn chia sẻ kinh nghiệm học lập trình và các kỹ năng mà anh đã trải qua trong suốt quá trình học và làm việc với tư cách là người đi trước cũng như là một Developer Full Stack, nên anh đã quyết định xuất bản sách')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0004', N'Cơ sở dữ liệu', N'DM003', N'TL001', N'Hoàng Thị Mỹ Lệ', N'NXB Công nghệ thông tin', 2016, 3, N'Với mong muốn chia sẻ kinh nghiệm học lập trình và các kỹ năng mà anh đã trải qua trong suốt quá trình học và làm việc với tư cách là người đi trước cũng như là một Developer Full Stack, nên anh đã quyết định xuất bản sách')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0005', N'Tin học văn phòng', N'DM003', N'TL001', N'Hoàng Thị Mỹ Lệ', N'NXB Công nghệ thông tin', 2016, 3, N'Với mong muốn chia sẻ kinh nghiệm học lập trình và các kỹ năng mà anh đã trải qua trong suốt quá trình học và làm việc với tư cách là người đi trước cũng như là một Developer Full Stack, nên anh đã quyết định xuất bản sách')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0006', N'Bơm nhiệt', N'DM002', N'TL001', N'Nguyễn Đức Lợi', N'NXB Cơ Khí', 2018, 3, N'Giáo trình gồm có 10 chương, trình bày các vấn đề về cơ cấu máy, phân tích động lực học cơ cấu máy, các vấn đề cơ bản trong thiết kế truyền động cơ khí, thiết kế các bộ truyền cơ khí và bộ phận đỡ nổi các bộ truyền. ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0007', N'Cơ sở thiết kế máy', N'DM002', N'TL001', N'Nguyễn Đức Lợi', N'NXB Cơ Khí', 2018, 3, N'Giáo trình gồm có 10 chương, trình bày các vấn đề về cơ cấu máy, phân tích động lực học cơ cấu máy, các vấn đề cơ bản trong thiết kế truyền động cơ khí, thiết kế các bộ truyền cơ khí và bộ phận đỡ nổi các bộ truyền. ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0008', N'Đo lường nhiệt', N'DM002', N'TL001', N'Võ Huy Hoàng', N'NXB Cơ Khí', 2018, 3, N'Giáo trình gồm có 10 chương, trình bày các vấn đề về cơ cấu máy, phân tích động lực học cơ cấu máy, các vấn đề cơ bản trong thiết kế truyền động cơ khí, thiết kế các bộ truyền cơ khí và bộ phận đỡ nổi các bộ truyền. ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0009', N'Nhiên liệu sạch', N'DM002', N'TL001', N'Nguyễn Đức Lợi', N'NXB Cơ Khí', 2018, 3, N'Giáo trình gồm có 10 chương, trình bày các vấn đề về cơ cấu máy, phân tích động lực học cơ cấu máy, các vấn đề cơ bản trong thiết kế truyền động cơ khí, thiết kế các bộ truyền cơ khí và bộ phận đỡ nổi các bộ truyền. ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0010', N'Giáo trình kỹ thuật nhiệt', N'DM002', N'TL001', N'Nguyễn Đức Lợi', N'NXB Cơ Khí', 2018, 3, N'Giáo trình gồm có 10 chương, trình bày các vấn đề về cơ cấu máy, phân tích động lực học cơ cấu máy, các vấn đề cơ bản trong thiết kế truyền động cơ khí, thiết kế các bộ truyền cơ khí và bộ phận đỡ nổi các bộ truyền. ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0011', N'Ngoại ngữ 1', N'DM005', N'TL002', N'Nguyễn Như Hiền', N'NXB Ngoại ngữ', 2010, 1, N'Nội dung chính của sách, gồm từ mới, mẫu câu được giới thiệu bằng hình ảnh trực quan kết hợp với việc nghe đĩa,
								kế đến là những bài tập đọc hiểu. Các chủ điểm ngữ pháp được đưa vào sách một cách nhẹ nhàng và tự nhiên thông qua 
								các tình huống thực tế.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0012', N'Grammar in use', N'DM005', N'TL002', N'Nguyễn Đức Trí', N'NXB Ngoại ngữ', 2018, 4, N'Nội dung chính của sách, gồm từ mới, mẫu câu được giới thiệu bằng hình ảnh trực quan kết hợp với việc nghe đĩa,
								kế đến là những bài tập đọc hiểu. Các chủ điểm ngữ pháp được đưa vào sách một cách nhẹ nhàng và tự nhiên thông qua 
								các tình huống thực tế.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0013', N'Listen carefully', N'DM005', N'TL002', N'Nguyễn Như Hiền', N'NXB Ngoại ngữ', 2018, 2, N'Nội dung chính của sách, gồm từ mới, mẫu câu được giới thiệu bằng hình ảnh trực quan kết hợp với việc nghe đĩa,
								kế đến là những bài tập đọc hiểu. Các chủ điểm ngữ pháp được đưa vào sách một cách nhẹ nhàng và tự nhiên thông qua 
								các tình huống thực tế.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0014', N'Ngoại ngữ cơ bản', N'DM005', N'TL002', N'Nguyễn Như Hiền', N'NXB Ngoại ngữ', 2018, 2, N'Nội dung chính của sách, gồm từ mới, mẫu câu được giới thiệu bằng hình ảnh trực quan kết hợp với việc nghe đĩa,
								kế đến là những bài tập đọc hiểu. Các chủ điểm ngữ pháp được đưa vào sách một cách nhẹ nhàng và tự nhiên thông qua 
								các tình huống thực tế.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0015', N'Ngoại ngữ 2', N'DM005', N'TL002', N'Nguyễn Như Hiền', N'NXB Ngoại ngữ', 2018, 1, N'Nội dung chính của sách, gồm từ mới, mẫu câu được giới thiệu bằng hình ảnh trực quan kết hợp với việc nghe đĩa,
								kế đến là những bài tập đọc hiểu. Các chủ điểm ngữ pháp được đưa vào sách một cách nhẹ nhàng và tự nhiên thông qua 
								các tình huống thực tế.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0016', N'Kỹ thuật xử lý tín hiệu điều khiển', N'DM001', N'TL001', N'	Phạm Ngọc Thắng', N'NXB Điện-Điện Tử', 2014, 1, N'Giáo trình này được sử dụng làm tài liệu học tập cho sinh viên các khối ngành kỹ thuật và các ngành có liên quan đến kỹ thuật.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0017', N'Bài tập vi điều khiển và PLC', N'DM001', N'TL001', N'Đặng Văn Tuệ', N'NXB Điện-Điện Tử', 2014, 4, N'')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0018', N'Khí cụ điện - kết cấu, sử dụng và sửa chữa', N'DM001', N'TL001', N'Nguyễn Xuân Phú', N'NXB Điện-Điện Tử', 2014, 2, N'Giáo trình này được sử dụng làm tài liệu học tập cho sinh viên các khối ngành kỹ thuật và các ngành có liên quan đến kỹ thuật.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0019', N'Sổ tay chuyên ngành điện', N'DM001', N'TL002', N'Tăng Văn Mùi - Trần Duy Nam', N'NXB Điện-Điện Tử', 2013, 2, N'Giáo trình này được sử dụng làm tài liệu học tập cho sinh viên các khối ngành kỹ thuật và các ngành có liên quan đến kỹ thuật.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0020', N'Bài tập điều khiển tự động', N'DM001', N'TL001', N'	Nguyễn Công Phương', N'NXB Điện-Điện Tử', 2013, 1, N'Giáo trình này được sử dụng làm tài liệu học tập cho sinh viên các khối ngành kỹ thuật và các ngành có liên quan đến kỹ thuật.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0021', N'Sổ tay máy làm đất và làm đường', N'DM004', N'TL002', N'Lưu Bá Thuận', N'NXB Xây dựng', 2015, 10, N'Cuốn sách này nhằm hệ thống hóa và trang bị các khái niệm, thông tin cơ bản về các hệ thống kỹ thuật trong công trình cho các sinh viên trong trường Đại học Xây dựng nói riêng cũng như các trường đại học có đạo tạo ngành kỹ thuật xây dựng.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0022', N'Móng cọc phân tích và thiết kế', N'DM004', N'TL001', N'Nguyễn Thái', N'NXB Xây dựng', 2014, 4, N'Cuốn sách này nhằm hệ thống hóa và trang bị các khái niệm, thông tin cơ bản về các hệ thống kỹ thuật trong công trình cho các sinh viên trong trường Đại học Xây dựng nói riêng cũng như các trường đại học có đạo tạo ngành kỹ thuật xây dựng.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0023', N'Cấu tạo bê tông cốt thép', N'DM004', N'TL001', N'Bộ Xây dựng', N'NXB Xây dựng', 2014, 2, N'Cuốn sách này nhằm hệ thống hóa và trang bị các khái niệm, thông tin cơ bản về các hệ thống kỹ thuật trong công trình cho các sinh viên trong trường Đại học Xây dựng nói riêng cũng như các trường đại học có đạo tạo ngành kỹ thuật xây dựng.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [soLuongCon], [TomTatND]) VALUES (N'S0024', N'Kết cấu thép - Công trình đặc biệt', N'DM004', N'TL001', N'GS.TS.Phạm Văn Hội ', N'NXB Xây dựng', 2013, 2, N'Cuốn sách này nhằm hệ thống hóa và trang bị các khái niệm, thông tin cơ bản về các hệ thống kỹ thuật trong công trình cho các sinh viên trong trường Đại học Xây dựng nói riêng cũng như các trường đại học có đạo tạo ngành kỹ thuật xây dựng.')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaDMSach], [MaTheLoai], [TacGia], [NXB], [NamXuatBan], [SoLuongCon], [TomTatND]) VALUES (N'S0025', N'Kết cấu bê tông cốt thép - Phần cấu kiện cơ bản', N'DM004', N'TL001', N'Phan Quang Minh', N'NXB Xây dựng', 2013, 1, N'Cuốn sách này nhằm hệ thống hóa và trang bị các khái niệm, thông tin cơ bản về các hệ thống kỹ thuật trong công trình cho các sinh viên trong trường Đại học Xây dựng nói riêng cũng như các trường đại học có đạo tạo ngành kỹ thuật xây dựng.')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MatKhau], [TenNguoiDung], [NgaySinh], [GioiTinh], [Email], [SDT], [Status], [SoLuongMuon]) VALUES (N'1911505310118', N'abc123', N'Cao Thị Thúy Hằng', CAST(N'2001-09-02' AS Date), 2, N'thuyhangfr01@gmail.com', N'0776155064', 1, 3)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MatKhau], [TenNguoiDung], [NgaySinh], [GioiTinh], [Email], [SDT], [Status], [SoLuongMuon]) VALUES (N'1911505310123', N'abc123', N'Lê Quốc Tuấn', CAST(N'2001-07-09' AS Date), 1, N'lequoctuan@gmail.com', N'0777443873', 1, 1)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MatKhau], [TenNguoiDung], [NgaySinh], [GioiTinh], [Email], [SDT], [Status], [SoLuongMuon]) VALUES (N'1911505310124', N'abc123', N'Võ Xuân Phúc', CAST(N'2001-07-09' AS Date), 1, N'voxuanphuc@gmail.com', N'0777443873', 1, 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MatKhau], [TenNguoiDung], [NgaySinh], [GioiTinh], [Email], [SDT], [Status], [SoLuongMuon]) VALUES (N'1911505310125', N'abc123', N'Nguyễn Thị Thu Thủy', CAST(N'2001-07-09' AS Date), 2, N'thuthuy@gmail.com', N'0777443873', 1, 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MatKhau], [TenNguoiDung], [NgaySinh], [GioiTinh], [Email], [SDT], [Status], [SoLuongMuon]) VALUES (N'1911505310132', N'abc123', N'Nguyễn Đình Khoa', CAST(N'2001-07-09' AS Date), 1, N'nguyendinhkhoa19t1@gmail.com', N'0777443873', 1, 3)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL001', N'Giáo trình học')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL002', N'Sách tham khảo')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL003', N'Văn hóa lịch sử')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL004', N'Chính trị, Pháp luật')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL005', N'Tạp chí')
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ('1') FOR [Status]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((0)) FOR [SoLuongMuon]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaDMSach])
REFERENCES [dbo].[DanhMucSach] ([MaDMSach])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([Email] like '[a-z]%@%'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([SDT] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR [SDT] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD CHECK  (([Email] like '[a-z]%@%'))
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD CHECK  (([SDT] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR [SDT] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER DATABASE [QuanLyThuVien_LHU] SET  READ_WRITE 
GO
USE [master]
GO