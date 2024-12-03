namespace BookStore;

using BookStore.Persistance;
using BookStore.Middleware;
using BookStore.Repositories;
using BookStore.Repositories.Interfaces;
using BookStore.Services;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews(options => {
            options.Filters.Add<ControllerExceptionFilter>();
        });
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));
        builder.Services.AddAutoMapper(typeof(Program));

        RegisterApplicationServices(builder.Services);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/store/error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=site}/{action=index}/{id?}");

        app.Run();
    }

    public static void RegisterApplicationServices(IServiceCollection services)
    {
        services.AddScoped<IAuthorQueryRepository, AuthorQueryRepository>();
        services.AddScoped<IAuthorQueryService, AuthorQueryService>();
        services.AddScoped<IAuthorCommandRepository, AuthorCommandRepository>();
        services.AddScoped<IAuthorCommandService, AuthorCommandService>();
    }
}

