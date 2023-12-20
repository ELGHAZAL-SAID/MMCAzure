using MMC.Domain.IRepositories;
using MMC.Application.Mapping;
using MMC.Infrastructure.Repositories;
using MMC.Application.Interfaces;
using MMC.Application.Services;
using MMC.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfiles));



builder.Services.AddScoped<DBC>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<ISupportRepository, SupportRepository>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();

builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();
builder.Services.AddScoped<ISupportService, SupportService>();



var app = builder.Build(); //builder 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
