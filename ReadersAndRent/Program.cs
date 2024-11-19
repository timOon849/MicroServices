using ReadersAndRent.Model;
using Microsoft.EntityFrameworkCore;
using ReadersAndRent.DB;
using ReadersAndRent.Interfaces;
using ReadersAndRent.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IReadersService, ReaderService>();
builder.Services.AddScoped<IhistoryService, HistoryService>();
builder.Services.AddDbContext<DBCon>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbString")), ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
