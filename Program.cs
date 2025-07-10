using Microsoft.EntityFrameworkCore;
using ITDocumentation.Data;
using Radzen;
using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>();


//Radzen Services 
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<AuthTest>();
builder.Services.AddHttpClient();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UsePathBase("/itdocs/");
app.UseStaticFiles();
app.UseRouting();
app.UseCors(builder => {
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{Controller=Upload}/{action=single}/{parent?}/{pageID?}");

});
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
