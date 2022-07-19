using AutoMapper;
using ConsultaClima.API.ViewModels;
using ConsultaClima.Domain.Entities;
using ConsultaClima.Infra.Context;
using ConsultaClima.Infra.Interfaces;
using ConsultaClima.Infra.Repositories;
using ConsultaClima.Services.DTO;
using ConsultaClima.Services.Interfaces;
using ConsultaClima.Services.Services;
using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ConsultaClima.API
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
            services.AddControllers();
            services.AddSingleton(cfg => Configuration);

            
            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Estado, EstadoDTO>().ReverseMap();
                cfg.CreateMap<EstadoViewModel, EstadoDTO>().ReverseMap();
                
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region Database
            
            services.AddDbContext<ConsultaClimaContext>(options => options
                .UseSqlServer(Configuration["ConnectionStrings:ConsultaClimaAPISqlServer"])
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())), 
            ServiceLifetime.Transient);

            #endregion

            #region Repositories

            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();

            #endregion

            #region Services

            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IEstadoService, EstadoService>();

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ConsultaClima API",
                    Version = "v1",
                    Description = "API de consulta de clima.",
                    Contact = new OpenApiContact
                    {
                        Name = "José Mauro da Silva",
                        Email = "jzmsmauro@hotmail.com"
                    },
                });        
            });

            #endregion

            #region Mediator

            services.AddMediatR(typeof(Startup));
      
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsultaClima.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
