using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers(); // for attribute routing


// for conventional routing
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
app.Run();
 