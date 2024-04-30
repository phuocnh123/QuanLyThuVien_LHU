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
    public class NhanVienController : Controller
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public NhanVienController(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetNhanViens()
        {
            var nhanViens = await _repository.GetAllNhanViens();
            var result = _mapper.Map<IEnumerable<GetNhanVienDto>>(nhanViens);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhanVien([Required] string id)
        {
            var nhanVien = await _repository.GetNhanVienById(id);
            if (nhanVien == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã nhân viên không tôn tại" }) { StatusCode = 400 };

            var result = _mapper.Map<GetNhanVienDto>(nhanVien);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNhanVien([FromBody] CreateNhanVienDto nhanVienDto)
        {
            var nhanVienEntity = await _repository.GetNhanVienById(nhanVienDto.MaNhanVien);
            if (nhanVienEntity != null) return BadRequest($"Nhân viên {nhanVienDto.MaNhanVien} đã tồn tại");

            var newNhanVien = _mapper.Map<NhanVien>(nhanVienDto);
            await _repository.CreateNewNhanVien(newNhanVien);
            await _repository.SaveChangesAsync();
            //var result = _mapper.Map<CreateNhanVienDto>(nhanVienDto);

            return Ok(nhanVienDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([Required] string id, [FromBody] UpdateNhanVienDto nhanVienDto)
        {
            var nhanVien = await _repository.GetNhanVienById(id);
            if (nhanVien == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã nhân viên không tôn tại" }) { StatusCode = 400 };

            var updateNhanVien = _mapper.Map(nhanVienDto, nhanVien);
            await _repository.UpdateNhanVien(nhanVien);
            await _repository.SaveChangesAsync();

            //var result = _mapper.Map<UpdateNhanVienDto>(nhanVien);
            return Ok(nhanVienDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([Required] string id)
        {
            var product = await _repository.GetNhanVienById(id);
            if (product == null)
                return new ObjectResult(new Response { Code = 400, Message = $"Không tìm thấy nhân viên có Id {id}" });

            await _repository.DeleteNhanVien(id);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
