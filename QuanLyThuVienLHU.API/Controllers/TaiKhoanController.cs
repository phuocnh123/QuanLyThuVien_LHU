using AutoMapper;
using infrastructure.repositories;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVienLHU.API.DTOs.TaiKhoanDto;
using QuanLyThuVienLHU.API.Helpers;
using System.ComponentModel.DataAnnotations;
using QuanLyThuVienLHU.API.Helpers;

namespace QuanLyThuVienLHU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanRepository _repository;
        private readonly IMapper _mapper;
        public TaiKhoanController(ITaiKhoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetTaiKhoans()
        {
            var taiKhoans = await _repository.GetAllTaiKhoans();
            var result = _mapper.Map<IEnumerable<GetTaiKhoanDto>>(taiKhoans);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaiKhoan([Required] string id)
        {
            var taiKhoan = await _repository.GetTaiKhoanById(id);
            if (taiKhoan == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã tài khoản không tôn tại" }) { StatusCode = 400 };

            var result = _mapper.Map<GetTaiKhoanDto>(taiKhoan);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateTaiKhoan")]
        public async Task<IActionResult> CreateTaiKhoan([FromBody] CreateTaiKhoanDto taiKhoanDto)
        {
            var taiKhoanEntity = await _repository.GetTaiKhoanById(taiKhoanDto.MaTaiKhoan);
            if (taiKhoanEntity != null) return BadRequest($"Tài khoản {taiKhoanDto.MaTaiKhoan} đã tồn tại");

            if(!RegexUtilities.IsValidEmail(taiKhoanDto.Email))
            {
                return new ObjectResult(new Response { Code = 500, Message = "Email không hợp lệ" }) { StatusCode = 500 };
            }

            var newTaiKhoan = _mapper.Map<TaiKhoan>(taiKhoanDto);
            await _repository.CreateNewTaiKhoan(newTaiKhoan);

            await _repository.SaveChangesAsync();

            return Ok(taiKhoanDto);
        }

        [HttpPut]
        [Route("UpdateTaiKhoan")]
        public async Task<IActionResult> UpdateTaiKhoan([Required] string id, [FromBody] UpdateTaiKhoanDto taiKhoanDto)
        {
            var taiKhoan = await _repository.GetTaiKhoanById(id);
            if (taiKhoan == null)
                return new ObjectResult(new Response { Code = 400, Message = "Mã tài khoản không tôn tại" }) { StatusCode = 400 };

            if (!RegexUtilities.IsValidEmail(taiKhoanDto.Email) )
            {
                return new ObjectResult(new Response { Code = 500, Message = "Email không hợp lệ" }) { StatusCode = 500 };
            }
       
            if (!int.TryParse(taiKhoanDto.Sdt, out int SDT) || (taiKhoanDto.Sdt.Length != 10 && taiKhoanDto.Sdt.Length != 11))
            {
                return new ObjectResult(new Response { Code = 500, Message = "Số điện thoại không hợp lệ" }) { StatusCode = 500 };
            }

            var updateTaiKhoan = _mapper.Map(taiKhoanDto, taiKhoan);
            await _repository.UpdateTaiKhoan(taiKhoan);
            await _repository.SaveChangesAsync();

            return Ok(taiKhoanDto);
        }
        #endregion
    }
}