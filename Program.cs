using Microsoft.EntityFrameworkCore;
using backend_autores.DB;
using backend_autores.Controllers;
using backend_autores.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DbContextAutores>(options =>
options.UseSqlite("Data Source=autores.db"));
builder.Services.AddScoped<IObraService, ObraService>();
builder.Services.AddControllers();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbContextAutores>();
    dbContext.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(policy =>
    policy.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin()
);
app.MapControllers();
app.UseHttpsRedirection();



app.Run();

