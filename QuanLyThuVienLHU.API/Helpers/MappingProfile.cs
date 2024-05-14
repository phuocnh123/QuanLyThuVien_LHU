using AutoMapper;
using QuanLyThuVienLHU.API.DTOs.NhanVienDto;
using Infrastructure.Entities;
using QuanLyThuVienLHU.API.DTOs.ChiTietPhieuMuonDto;
using QuanLyThuVienLHU.API.DTOs.TaiKhoanDto;
using QuanLyThuVienLHU.API.DTOs.PhieuMuonDto;

namespace QuanLyThuVienLHU.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NhanVien, GetNhanVienDto>();
            CreateMap<CreateNhanVienDto, NhanVien>();
            CreateMap<CreateNhanVienDto, GetNhanVienDto>();
            CreateMap<UpdateNhanVienDto, NhanVien>();
            CreateMap<UpdateNhanVienDto, GetNhanVienDto>();

            CreateMap<TaiKhoan, GetTaiKhoanDto>();
            CreateMap<UpdateTaiKhoanDto, TaiKhoan>();
            CreateMap<UpdateTaiKhoanDto, GetTaiKhoanDto>();
            CreateMap<CreateTaiKhoanDto, TaiKhoan>();
            CreateMap<CreateTaiKhoanDto, GetTaiKhoanDto>();

            CreateMap<CreatePhieuMuonDto, PhieuMuon>();
            CreateMap<PhieuMuon, GetPhieuMuonInfosDto>();

            CreateMap<UpdateChiTietPhieuMuonDto, ChiTietPhieuMuon>();
            //CreateMap<ThongTinTraSachDto, PhieuMuon>();
        }
    }
}
