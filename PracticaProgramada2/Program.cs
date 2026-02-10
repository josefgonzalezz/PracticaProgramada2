using PracticaProgramada2.Data;
using PracticaProgramada2.Repositories;
using PracticaProgramada2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);


builder.Services.AddScoped<IVideojuegoRepository, VideojuegoRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();


builder.Services.AddScoped<IVideojuegoService, VideojuegoService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
