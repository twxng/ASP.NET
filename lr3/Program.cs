using lr3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddScoped<ICalcService, CalcService>();
builder.Services.AddTransient<ICurrentTimeCheckerService, CurrentTimeCheckerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
		

}

app.UseHttpsRedirection()
		.UseStaticFiles()
			.UseRouting()
			.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
