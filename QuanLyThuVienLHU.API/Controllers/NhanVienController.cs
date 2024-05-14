using AutoMapper;
using QuanLyThuVienLHU.API.DTOs.NhanVienDto;
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
        [Route("CreateNhanVien")]
        public async Task<IActionResult> CreateNhanVien([FromBody] CreateNhanVienDto nhanVienDto)
        {
            var nhanVienEntity = await _repository.GetNhanVienById(nhanVienDto.MaNhanVien);
            if (nhanVienEntity != null) return BadRequest($"Nhân viên {nhanVienDto.MaNhanVien} đã tồn tại");

            if (!int.TryParse(nhanVienDto.Sdt, out int SDT) || (nhanVienDto.Sdt.Length != 10 && nhanVienDto.Sdt.Length != 11))
            {
                return new ObjectResult(new Response { Code = 500, Message = "Số điện thoại không hợp lệ" }) { StatusCode = 500 };
            }

            var newNhanVien = _mapper.Map<NhanVien>(nhanVienDto);
            await _repository.CreateNewNhanVien(newNhanVien);
            await _repository.SaveChangesAsync();
            //var result = _mapper.Map<CreateNhanVienDto>(nhanVienDto);

            return Ok(nhanVienDto);
        }

        [HttpPut]
        [Route("UpdateNhanVien")]
        public async Task<IActionResult> UpdateNhanVien([Required] string id, [FromBody] UpdateNhanVienDto nhanVienDto)
        {
            var nhanVien = await _repository.GetNhanVienById(id);
            if (nhanVien == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã nhân viên không tôn tại" }) { StatusCode = 400 };

            if (!int.TryParse(nhanVienDto.Sdt, out int SDT) || (nhanVienDto.Sdt.Length != 10 && nhanVienDto.Sdt.Length != 11))
            {
                return new ObjectResult(new Response { Code = 500, Message = "Số điện thoại không hợp lệ" }) { StatusCode = 500 };
            }

            if (!RegexUtilities.IsValidEmail(nhanVienDto.Email))
            {
                return new ObjectResult(new Response { Code = 500, Message = "Email không hợp lệ" }) { StatusCode = 500 };
            }

            var updateNhanVien = _mapper.Map(nhanVienDto, nhanVien);
            await _repository.UpdateNhanVien(updateNhanVien);
            await _repository.SaveChangesAsync();

            //var result = _mapper.Map<UpdateNhanVienDto>(nhanVien);
            return Ok(nhanVienDto);
        }

        [HttpDelete]
        [Route("DeleteNhanVien")]
        public async Task<IActionResult> DeleteNhanVien([Required] string id)
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
