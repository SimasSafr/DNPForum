using Application;
using Application.Contracts;
using BlazorUI.Authentication;
using BlazorUI.Data;
using Contracts.Services;
using JsonDataAccess;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddScoped<IPostService, PostServiceImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IUserDAO, JsonUserDAO>();
builder.Services.AddScoped<IPostDAO, JsonPostDAO>();

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedIn", a => a.RequireAuthenticatedUser().RequireClaim("IsLoggedIn", "true"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();