using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVienLHU.API.Helpers;
using System.ComponentModel.DataAnnotations;
using Infrastructure.ServicesRepositories;
using QuanLyThuVienLHU.API.DTOs.ChiTietPhieuMuonDto;
using Infrastructure.Entities;
using QuanLyThuVienLHU.API.DTOs.NhanVienDto;

namespace QuanLyThuVienLHU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChiTietPhieuMuonController : Controller
    {
        private readonly IChiTietPhieuMuonRepository _chiTietPhieuMuonRepository;
        private readonly QuanLyThuVien_LHUContext _context;
        private readonly IMapper _mapper;
        public ChiTietPhieuMuonController(IChiTietPhieuMuonRepository chiTietPhieuMuonRepository, QuanLyThuVien_LHUContext context, IMapper mapper)
        {
            _chiTietPhieuMuonRepository = chiTietPhieuMuonRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetMaSachByMaPhieuMuon")]
        public List<string> GetMaSachByMaPhieuMuon(string maPhieuMuon)
        { 
            List<string> maSachs = _context.ChiTietPhieuMuons.Where(o => o.MaPhieuMuon == maPhieuMuon).Select(o => o.MaSach).ToList();
            return maSachs;
        }

        [HttpPut]
        [Route("TraSach")]
        public async Task<IActionResult> UpdateChiTietPhieuMuon([Required] string maPhieuMuon, [Required] string maSach, [FromBody] UpdateChiTietPhieuMuonDto phieuMuonDto)
        {
            var phieuMuon = await _chiTietPhieuMuonRepository.GetChiTietPhieuMuonById(maPhieuMuon, maSach);
            if (phieuMuon == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã phiếu mượn không tôn tại" }) { StatusCode = 400 };

            var updatePhieuMuon = _mapper.Map(phieuMuonDto, phieuMuon);
            await _chiTietPhieuMuonRepository.UpdateChiTietPhieuMuon(phieuMuon);
            await _chiTietPhieuMuonRepository.SaveChangesAsync();

            return Ok(phieuMuonDto);
        }

    }
}
