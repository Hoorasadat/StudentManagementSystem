using EnrollmentManagementSystem.BLL.Interfaces;
using InstructorManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.BLL.Interfaces;
using StudentManagementSystem.BLL.Repositories;
using StudentManagementSystem.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<MemoryDbContext>();
//builder.Services.AddScoped<IStudentRepository, MockStudentRepository>();


builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, SQLStudentRepository>();
builder.Services.AddScoped<IEnrollmentRepository, SQLEnrollmentRepository>();
builder.Services.AddScoped<ICourseRepository, SQLCourseRepository>();

builder.Services.AddHttpClient<IInstructorRepository, InstructorRepository>(client => client.BaseAddress = new Uri("https://localhost:7162/api/Instructors/"));


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
