using Microsoft.EntityFrameworkCore;
using MovieLandAPI.Models;


// Services

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration["DefaultConnection"])
);

builder.Services.AddAutoMapper(typeof(Program));



// Middlewares.

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
