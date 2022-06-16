using Cenfotur.Data;
using Cenfotur.Entidad.AutoMapper;
using Cenfotur.Entidad.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cenfotur.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Agregar servicios para la aplicaci�n mios.
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
//services.AddAutoMapper(typeof(Program).Assembly); 
            services.AddAutoMapper(typeof(AutoMapperProfiles)); // agrega autoMapper
//services.AddRazorPages().AddRazorRuntimeCompilation(); //activa el razor update para las web

            /// se usa para el login
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.Configure<ArchivoSettings>(Configuration.GetSection("ArchivoSettings"));

//services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}