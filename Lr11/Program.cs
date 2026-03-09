using Lr11.Filters;
using Lr11.Services;

var builder = WebApplication.CreateBuilder(args);

// Реєстрація сервісів
builder.Services.AddSingleton<ILogService, FileLogService>();

builder.Services.AddControllersWithViews(options =>
{
    // Глобальні фільтри, що реалізують вимоги роботи
    options.Filters.Add<ActionLoggingFilter>();
    options.Filters.Add<UniqueUserCountingFilter>();
});

var app = builder.Build();

// Налаштування конвеєра HTTP-запитів
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

