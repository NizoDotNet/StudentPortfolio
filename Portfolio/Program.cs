using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Claims;
using Portfolio.Data;
using Portfolio.DependencyInjection;
using Portfolio.Entities;
using Portfolio.Repository;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PortfolioDb") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));



builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("SuperAdminPolicy", polbuilder => polbuilder.RequireClaim("Role", MyClaimValues.SuperAdmin));
    op.AddPolicy("TeacherPolicy", polbuilder => polbuilder.RequireClaim("Role", MyClaimValues.SuperAdmin, MyClaimValues.Teacher));
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = false;
});



builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages(op =>
{
    op.Conventions.AuthorizeFolder("/SubjectManager", "TeacherPolicy");
});


builder.Services.AddMyDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


