using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
var app = builder.Build();

app.MapDefaultControllerRoute();
app.Run();
