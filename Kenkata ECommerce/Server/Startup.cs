using Kenkata_ECommerce.Server.Interfaces;
using Kenkata_ECommerce.Server.Models;
using Kenkata_ECommerce.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using System.IO;
using System.Linq;

namespace Kenkata_ECommerce.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KenkataDbSettings>(Configuration.GetSection(nameof(KenkataDbSettings)));
            services.AddSingleton<IKenkataDb>(sp => sp.GetRequiredService<IOptions<KenkataDbSettings>>().Value);

            services.AddSingleton<IProductCatalogService, ProductCatalogService>();
            services.AddSingleton<ICustomerCatalogService, CustomerCatalogService>();
            services.AddSingleton<IShoppingCartCatalogService, ShoppingCartService>();
            services.AddSingleton<IOrderCatalogService, OrderCatalogService>();

           
           
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            // This let us get the pics outside the project.
            app.UseStaticFiles(new StaticFileOptions{FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../../pics" )),RequestPath = "/images"});
            app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../../Image - XD")), RequestPath = "/siteImages" });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
