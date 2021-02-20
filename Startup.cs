using ChatApp.Data;
using ChatApp.Hubs;
using ChatApp.Model;
using ChatApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp
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
            services.Configure<ChatAppDatabaseSettings>(
            Configuration.GetSection(nameof(ChatAppDatabaseSettings)));

            services.AddSingleton<IChatAppDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ChatAppDatabaseSettings>>().Value);
            services.AddSingleton<IMessageService, MongoMessageService>();
            services.AddSignalR();


            //SQL için aktif edilmelidir.
            /*services.AddDbContext<ChatDbContext>(options=>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            */
            //SQL kullanılmak isternirse bu kısım aktif edilip mongo kapatılmalıdır.
            //services.AddScoped<IMessageService, SqlMessageService>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
