using Mango.Web.Services;
using Mango.Web.Services.IServices;
using Microsoft.Extensions.Configuration;


namespace Mango.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add by Vip---
           

            builder.Services.AddHttpClient<IProductService, ProductService>();

            //SD.ProductAPIBase = builder.Configuration["ServiceUrl.ProductAPI"];
            //SD.ProductAPIBase = "https://localhost:7044"; /// need to resolve

            var provider = builder.Services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();
            SD.ProductAPIBase = configuration.GetValue<string>("ServiceUrl:ProductAPI");

            builder.Services.AddScoped<IProductService, ProductService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}