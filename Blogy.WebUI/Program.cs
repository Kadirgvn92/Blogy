using Blogy.DataAccessLayer.Context;
using Blogy.BusinessLayer.Container;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogyDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.ContainerDependencies();

builder.Services.RegisterValidator();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
