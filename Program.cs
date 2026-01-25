using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Common.Behaviors;
using WebBanHang.DbContextConfig;
using WebBanHang.Repository.Implement;
using WebBanHang.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// ⭐ QUAN TRỌNG: CHỈ 1 DÒNG DUY NHẤT
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
