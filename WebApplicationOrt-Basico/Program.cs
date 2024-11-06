using Microsoft.EntityFrameworkCore;
using WebApplicationOrt_Basico.Context;
using WebApplicationOrt_Basico.Context.WebApplicationOrt_Basico.Context;

namespace WebApplicationOrt_Basico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar el contexto de la base de datos
            builder.Services.AddDbContext<AppDatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionString:DBConnection"]));

            // Agregar servicios al contenedor
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configurar el pipeline de solicitudes HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
