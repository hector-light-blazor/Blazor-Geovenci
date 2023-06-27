using dymaptic.GeoBlazor.Core;
using Geovenci.Areas.Identity;
using Geovenci.Data;
using Geovenci.Data.Entities;
using Geovenci.Data.Extension;
using Geovenci.Data.Repositories;
using Geovenci.Data.Repositories.Interfaces;
using Geovenci.Service.Services;
using Geovenci.Service.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
//    options.UseNpgsql(connectionString));

builder.Services.AddDbContextFactory<GeovenciAppDbContext>(options =>
    options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GeovenciAppDbContext>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<IMapRepo, MapRepo>();
builder.Services.AddScoped<IMapService, MapService>();

//GeoBlazor
builder.Services.AddGeoBlazor();


//Add Mud Services
builder.Services.AddMudServices();

var app = builder.Build();


//Run Migrations.
app
.ApplyMigration<GeovenciAppDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
