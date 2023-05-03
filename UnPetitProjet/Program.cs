var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
//app.MapControllerRoute(
// name: "default",
// pattern: "{prenom}/{nom}",
// defaults:new {controller= "Welcome", action= "WelcomeName" }
//);
app.MapControllerRoute(
 name: "default",
 pattern: "{controller=Exercice}/{action=RedirigeListeClient}/{id?}");
app.Run();
