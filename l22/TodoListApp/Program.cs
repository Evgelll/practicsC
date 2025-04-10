using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;

namespace TodoListApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TodoDbContext>(options =>
            options.UseSqlite("Data Source=todo.db"));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Todo/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Todo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}