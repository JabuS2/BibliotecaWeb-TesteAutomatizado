using BibliotecaApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");


builder.Services.AddRazorPages();

// Configura o serviço de banco de dados com PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("BibliotecaConnectionString");
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseNpgsql(connectionString));



builder.Services.AddScoped<LivroService>();

var app = builder.Build();





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
