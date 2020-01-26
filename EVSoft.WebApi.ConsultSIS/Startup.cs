using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EVSoft.WebApi.ConsultSIS
{
    /// <summary>
    /// Class de inicio
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Consultar Afiliado SIS",
                    Description = "Servicio gratuito Consultar Afiliado SIS MINSA",
                    TermsOfService = new Uri("https://www.datosabiertos.gob.pe"),
                    Contact = new OpenApiContact
                    {
                        Name = "Enrique Incio Chapilliquen (EVSoft Consultores)",
                        Email = "enrique.incio@evsoftconsultores.com",
                        Url = new Uri("https://devenriqueincio.web.app/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://www.datosabiertos.gob.pe/dataset/minsa-consulta-de-afiliados-al-sis"),
                    }
                });
            });

            //----------------
            //Politica de CORS
            //----------------
            services.AddCors(option => {
                option.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()  //permitir cualquier encabezado me venga
                    .AllowAnyMethod()  //permite PUT, GET, POST, DEELETE .. etc
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();
            app.UseRouting();

            //-----------------------
            //Usar las politicas CORS
            //-----------------------
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
