using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseStaticFiles(new StaticFileOptions {FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Static")), 
                // указываем физический путь до папки с файлами
                RequestPath = "/Static" // запросы по этому url будут будут соотносится с файлами из указанной директории
            });

            app.UseEndpoints(endpoints =>
            {
                // Маппинг статических файлов

                endpoints.MapCss();
                endpoints.MapJs();
                endpoints.MapHtml();
            });
        }
    }
}