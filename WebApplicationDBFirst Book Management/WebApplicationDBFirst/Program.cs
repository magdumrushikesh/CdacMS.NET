using Microsoft.EntityFrameworkCore;
using WebApplicationDBFirst.Models;

namespace WebApplicationDBFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PracticeContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("PracticeContext")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=UserTbs}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
