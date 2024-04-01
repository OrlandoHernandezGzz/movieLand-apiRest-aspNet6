using Microsoft.EntityFrameworkCore;
using MovieLandAPI.Models;
using MovieLandAPI.Services;


// Services

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration["DefaultConnection"])
);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IFileStorage, LocalFileStore>();
builder.Services.AddHttpContextAccessor();


// Middlewares.

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
