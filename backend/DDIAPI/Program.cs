using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using DDIAPI.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DDIAPIContext>(opt => opt.UseSqlServer("Server=localhost,1433;Database=DDI;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;"));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouter(routes =>
{
    routes.MapGet("/", (HttpContext context) =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
});
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
