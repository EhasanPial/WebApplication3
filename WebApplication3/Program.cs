using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
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
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 4;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;
    option.Password.RequiredUniqueChars = 3;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

// Password Options

/*builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequiredLength = 4;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;
    option.Password.RequiredUniqueChars = 3;
});*/

builder.Services.AddMvc(config => {
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// +++--------------- Configure ---------------++++ //

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();


// for attribute routing


// for conventional routing
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
app.Run();
