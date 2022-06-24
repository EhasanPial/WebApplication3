using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);
//+++ --------------- Configure Services ---------------+++ //

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

// Connection to database
var connectionString = builder.Configuration.GetConnectionString("EmployeeDBConnection");
builder.Services.AddDbContextPool<AppDbContext>(x => x.UseSqlServer(connectionString));

// Identity Service
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// +++--------------- Configure ---------------++++ //

app.UseStaticFiles();
app.UseAuthentication();
app.UseMvc();
app.UseRouting();
app.MapControllers(); // for attribute routing


// for conventional routing
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
app.Run();
