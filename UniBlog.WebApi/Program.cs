using Microsoft.EntityFrameworkCore;
using UniBlog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<UniBlogDbContext>(b =>
{
    var connectionString = builder.Environment.IsDevelopment()
        ? builder.Configuration.GetConnectionString("DefaultConnection")
        : builder.Configuration.GetConnectionString("DefaultDockerConnection");
    b.UseSqlServer(connectionString);
    // b.AddInterceptors(new Commands());
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
