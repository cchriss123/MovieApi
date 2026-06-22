using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Seed;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieApiContext") ?? throw new InvalidOperationException("Connection string 'MovieApiContext' not found.")));


// Add services to the container.

builder.Services.AddControllers();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovieApiContext>();
    await DbSeeder.SeedAsync(context);
}



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();