using Hennis_Admin.Data;
using Hennis_DAL.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Syncfusion.Blazor;
using Hennis_Business.Repository.Interface;
using Hennis_Business.Repository;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzMzODc4QDMyMzAyZTMzMmUzMG9XNVJ5TFZqcmZPZDBVdXNNem1VK0cyYnhXU09manF6c2pVWmdZdG5aY1E9");

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<IPageRepository, PageRepository>();
builder.Services.AddScoped<IHtmlContentRepository, HtmlContentRepository>();
builder.Services.AddScoped<ILayoutZoneRepository, LayoutZoneRepository>();
builder.Services.AddScoped<ILayoutRepository, LayoutRepository>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();
