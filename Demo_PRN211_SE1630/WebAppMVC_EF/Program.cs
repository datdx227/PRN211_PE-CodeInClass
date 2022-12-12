using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//Add
builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//Edit

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}"
    );

app.Run();