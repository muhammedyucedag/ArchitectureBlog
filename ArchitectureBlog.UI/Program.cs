using ArchitectureBlog.Business;
using ArchitectureBlog.Core.Repositories;
using ArchitectureBlog.Core.Services;
using ArchitectureBlog.DataAccess;
using ArchitectureBlog.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureBlog.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddMvcCore();
            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgresqlConnection")));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

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

            app.MapControllerRoute( // area için program cs eklentisi
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}