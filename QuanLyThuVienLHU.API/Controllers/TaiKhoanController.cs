using AutoMapper;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVienLHU.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVienLHU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanRepository _repository;
        private readonly IMapper _mapper;
        public TaiKhoanControllerController(ITaiKhoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetTaiKhoan()
        {
            var taiKhoans = await _repository.GetAllTaiKhoans();
            var result = _mapper.Map<IEnumerable<GetNhanVienDto>>(taiKhoans);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaiKhoan([Required] string id)
        {
            var taiKhoan = await _repository.GetTaiKhoanId(id);
            if (taiKhoan == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã tài khoản không tôn tại" }) { StatusCode = 400 };

            var result = _mapper.Map<GetTaiKhoanDto>(taiKhoan);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaiKhoan([FromBody] CreateNhanVienDto taiKhoanDto)
        {
            var taiKhoanEntity = await _repository.GetTaiKhoanById(taiKhoanDto.MaTaiKhoan);
            if (taiKhoanEntity != null) return BadRequest($"Tài khoản {taiKhoanDto.MaTaiKhoan} đã tồn tại");

            var newTaiKhoan = _mapper.Map<TaiKhoan>(taiKhoanDto);
            await _repository.CreateNewTaiKhoan(newTaiKhoan);
            await _repository.SaveChangesAsync();
            //var result = _mapper.Map<CreateNhanVienDto>(nhanVienDto);

            return Ok(taiKhoanDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([Required] string id, [FromBody] UpdateTaiKhoanDto taiKhoanDto)
        {
            var taiKhoan = await _repository.GetTaiKhoanById(id);
            if (taiKhoan == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã Tài Kho không tôn tại" }) { StatusCode = 400 };

            var updateTaiKhoan = _mapper.Map(taiKhoanDto, taiKhoan);
            await _repository.UpdateTaiKhoan(taiKhoan);
            await _repository.SaveChangesAsync();

            //var result = _mapper.Map<UpdateNhanVienDto>(nhanVien);
            return Ok(taiKhoanDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([Required] string id)
        {
            var product = await _repository.GetTaiKhoanById(id);
            if (product == null)
                return new ObjectResult(new Response { Code = 400, Message = $"Không tìm thấy Tài Khoản có Id {id}" });

            await _repository.DeleteTaiKhoan(id);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}