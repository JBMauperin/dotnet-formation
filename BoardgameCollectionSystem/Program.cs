using BoardgameCollectionSystem.Repository;
using BoardgameCollectionSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// D�claration du context de base de donn�es pour l'injection de d�pendances
builder.Services.AddDbContext<LudoManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// D�claration des services pour l'injection de d�pendances
builder.Services.AddScoped<BoardGamesService>();
builder.Services.AddScoped<GamesService>();
builder.Services.AddScoped<PlayersService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();

app.Run();
