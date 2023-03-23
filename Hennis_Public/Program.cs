using Hennis_Business.Repository;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_Public.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM5MjE1NkAzMjMwMmUzNDJlMzBKZWd6aUp6eENlcitGSGt0d2JWQWRueDg3QmIyQm1rdk1aS1dySzlWUFFRPQ==");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddCors();

builder.Services.AddScoped<IPageRepository, PageRepository>();
builder.Services.AddScoped<IHtmlContentRepository, HtmlContentRepository>();
builder.Services.AddScoped<IPageTileRepository, PageTileRepository>();
builder.Services.AddScoped<IStaffImageRepository, StaffImageRepository>();
builder.Services.AddScoped<IHappeningsRepository, HappeningsRepository>();
builder.Services.AddScoped<IImageGalleryRepository, ImageGalleryRepository>();
builder.Services.AddScoped<IOnlineApplicationRepository, OnlineApplicationRepistory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
