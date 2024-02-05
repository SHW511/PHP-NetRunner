using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PNetRunner.Data;
using PNetRunner.Options;

namespace PNetRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddOptions<PhpSettings>().Bind(builder.Configuration.GetSection("PhpSettings"));
            builder.Services.AddSingleton<PhpRunner>();
            builder.Services.AddLogging();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Services.GetRequiredService<PhpRunner>().MapPhpContainers();

            app.Run();
        }
    }
}