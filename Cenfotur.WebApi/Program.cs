using Cenfotur.Data;
using Cenfotur.Entidad.AutoMapper;
using Cenfotur.Entidad.ViewModels;
using Cenfotur.WebApi;
using Cenfotur.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// var builder = WebApplication.CreateBuilder(args);
//
// // Agregar servicios para la aplicaci�n mios.
// builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// //builder.Services.AddAutoMapper(typeof(Program).Assembly); 
// builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));// agrega autoMapper
// //builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); //activa el razor update para las web
//
// /// se usa para el login
// builder.Services.AddControllers().AddNewtonsoftJson(options =>
//     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
// );
//
// //builder.Services.Configure<ArchivoSettings>(configuration.GetSection("ImageSettings"));
//
// //builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// builder.Services.AddCors(opciones =>
// {
//     opciones.AddDefaultPolicy(builder =>
//     {
//         builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
//     });
// });
//
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// //if (app.Environment.IsDevelopment())
// //{
//     app.UseSwagger();
//     app.UseSwaggerUI();
// //}
//
// //app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.UseCors();
//
// app.MapControllers();
//
// app.Run();

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().MigrateDatabase<ApplicationDbContext>().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}