using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services
    .AddMvc(setup => {
        setup.EnableEndpointRouting = false;
    });

builder.Services
    .AddDbContext<SportsStoreContext>()
    .AddTransient<IProductRepository, EFProductRepository>();
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMvc(routes =>
{
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(
        name: "pagination",
        template: "Product/Page{page}",
        defaults: new { Controller = "Product", action = "List" }
    );
});
app.Run();
#endregion