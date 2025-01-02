using Calendar.Application.Implements;
using Calendar.Common.Interfaces;
using Calendar.Repository.Enities;
using Calendar.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<DbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Calendar"))
//);

builder.Services.AddSingleton<CalendarContext>(options => new CalendarContext(builder.Configuration.GetConnectionString("Calendar")));

builder.Services.AddScoped<CalendarUseCase>();
builder.Services.AddScoped<ICalendarInterface, CalendarRepository>();
builder.Services.AddScoped<CalendarRepository>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


