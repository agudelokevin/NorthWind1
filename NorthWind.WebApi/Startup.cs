using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthWind.UseCases.CreateOrder; // Asegúrate de tener el namespace correcto para tus casos de uso

namespace NorthWind.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método se utiliza para configurar los servicios que la aplicación utilizará.
        public void ConfigureServices(IServiceCollection services)
        {
            // Agregar MediatR
            services.AddMediatR(typeof(Startup));

            // Configurar servicios como MVC, servicios de autenticación, bases de datos, etc.
            services.AddControllers();
        }

        // Este método se utiliza para configurar el pipeline de solicitud HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // En producción, manejar errores de manera más amigable.
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
