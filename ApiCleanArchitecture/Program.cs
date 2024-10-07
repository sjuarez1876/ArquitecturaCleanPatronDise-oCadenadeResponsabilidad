using ApiCleanArchitecture.Application;
using ApiCleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICarCompanyRepository, CarCompanyRepository>();

builder.Services.AddScoped<ICarCompanyHandler>(sp =>
    new CreateCarCompanyHandler(sp.GetRequiredService<ICarCompanyRepository>())
);
//builder.Services.AddScoped<ICarCompanyHandler>(sp =>
//    new DeleteCarCompanyHandler(sp.GetRequiredService<ICarCompanyRepository>())
//);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BDCarCompanyConnectionString")));


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
