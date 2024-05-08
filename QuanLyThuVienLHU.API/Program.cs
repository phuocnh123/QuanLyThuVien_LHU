using AutoMapper;
using infrastructure.repositories;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.ServicesRepositories;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVienLHU.API.Helpers;
using QuanLyThuVienLHU.API.Serivces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuanLyThuVien_LHUContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr"));
});

builder.Services.AddScoped(typeof(IRepositoryBaseAsync<>), typeof(RepositoryBaseAsync<>))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<INhanVienRepository, NhanVienRepository>()
                .AddScoped<ITaiKhoanRepository, TaiKhoanRepository>()
                .AddScoped<IChiTietPhieuMuonRepository, ChiTietPhieuMuonRepository>()
                .AddScoped<IPhieuMuonRepository, PhieuMuonRepository>()
                .AddScoped<ChiTietPhieuMuonService>();
;

builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
