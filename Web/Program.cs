using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    var config = builder.Configuration;

    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<NursBlogDbContext>(options =>
    {
        options.UseSqlServer(config.GetSection("Database:ConnectionString").Value);
    });

    builder.Services.AddScoped<PostService>();
    builder.Services.AddScoped<IPostRepository, PostRepository>();
}

var app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler();
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}