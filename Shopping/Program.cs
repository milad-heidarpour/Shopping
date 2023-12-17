using Shopping.Core.Interface;
using Shopping.Core.Service;
using Shopping.Database.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IBrand,BrandService>();
builder.Services.AddScoped<ICommodity,CommodityService>();
builder.Services.AddScoped<IAccount,AccountService>();
builder.Services.AddScoped<IClassification,ClassificationService>();
builder.Services.AddScoped<IUser,UserService>();
builder.Services.AddScoped<IFeature,FeatureService>();

const string scheme = "Shopping";
builder.Services.AddAuthentication(scheme).AddCookie(scheme, option =>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/Login";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);//machin key???? ??? ???? ????? ??? 
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.MapGet("/", () => "Hello World!");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Admin}/{action=Index}/{Id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}");
});

app.Run();
