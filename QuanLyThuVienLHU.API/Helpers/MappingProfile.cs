using AutoMapper;
using Infrastructure.DTOs;
using Infrastructure.Entities;

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
        }
    }
}
