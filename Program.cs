using BookLibrary.Data;
using BookLibrary.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
        policy.WithOrigins("https://localhost:44411") // Angular dev server
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// auto create instance of book service when requested
builder.Services.AddTransient<IBookService, BookService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
// Apply CORS
app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");


// Log all registered endpoints
// foreach (var endpoint in app.Services.GetService<EndpointDataSource>().Endpoints)
// {
//     Console.WriteLine(endpoint);
// }

app.Run();
