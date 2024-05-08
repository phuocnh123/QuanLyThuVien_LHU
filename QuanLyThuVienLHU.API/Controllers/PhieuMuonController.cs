using Infrastructure.Entities;
using Infrastructure.ServicesRepositories;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVienLHU.API.DTOs.ChiTietPhieuMuonDto;
using QuanLyThuVienLHU.API.DTOs.PhieuMuonDto;
using QuanLyThuVienLHU.API.Helpers;
using QuanLyThuVienLHU.API.Serivces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuanLyThuVienLHU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhieuMuonController : Controller
    {
        private readonly IPhieuMuonRepository _repository;
        private readonly ChiTietPhieuMuonService _chiTietPhieuMuonService;
        public PhieuMuonController(IPhieuMuonRepository repository, ChiTietPhieuMuonService chiTietPhieuMuonService)
        {
            _repository = repository;
            _chiTietPhieuMuonService = chiTietPhieuMuonService;
        }

        [HttpGet()]
        [Route("GetMaPhieuMuonsInfoByMaTaiKhoan")]
        public async Task<IActionResult> GetMaPhieuMuonsInfoByMaTaiKhoan([Required] string maTaiKhoan)
        {
            if (string.IsNullOrEmpty(maTaiKhoan))
                return new ObjectResult(new Response { Code = 400, Message = $"Mã tài khoản không được trống" }) { StatusCode = 400 };

            var phieuMuons = await _repository.GetPhieuMuonByMaTK(maTaiKhoan);

            if (phieuMuons == null || phieuMuons.Count == 0)
                return NotFound();

            return Ok(phieuMuons);
        }

        [HttpPost]
        [Route("CreatePhieuMuon")]
        public async Task<IActionResult> CreatePhieuMuon([FromBody] CreatePhieuMuonDto phieuMuonDto)
        {
            var phieuMuonEntity = await _repository.GetPhieuMuonById(phieuMuonDto.MaPhieuMuon);
            if (phieuMuonEntity != null) return BadRequest($"Phiếu mượn {phieuMuonDto.MaPhieuMuon} đã tồn tại");

            var newPhieuMuon = new PhieuMuon
            {
                MaPhieuMuon = phieuMuonDto.MaPhieuMuon,
                NgayMuon = DateTime.Now,
                SoNgayMuon = phieuMuonDto.SoNgayMuon,
                MaTaiKhoan = phieuMuonDto.MaTaiKhoan,
                MaNhanVien = phieuMuonDto.MaNhanVien,
                GhiChu = phieuMuonDto?.GhiChu,
                TrangThai = "Chưa trả",
            };

            await _repository.CreateNewPhieuMuon(newPhieuMuon);

            foreach (var sach in phieuMuonDto.DsSachsMuon)
            {
                CreateChiTietPhieuMuonDto ctPhieuMuonDto = new CreateChiTietPhieuMuonDto
                {
                    MaPhieuMuon = phieuMuonDto.MaPhieuMuon,
                    MaSach = sach.MaSach
                };
                await _chiTietPhieuMuonService.CreateChiTietPhieuMuon(ctPhieuMuonDto);
            }

            await _repository.SaveChangesAsync();

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            string newPhieuMuonJson = JsonSerializer.Serialize(newPhieuMuon, options);

            return Ok(newPhieuMuonJson);
        }

    }
}
