using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
var app = builder.Build();


app.UseRouting();
// app.UseMvcWithDefaultRoute();
/*app.UseEndpoints(Routes =>
{
    Routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});*/
app.UseMvcWithDefaultRoute();
app.Run();
