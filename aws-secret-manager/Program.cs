using AwsSecretManager.Data;
using aws_secret_manager.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Fetch connection string from AWS Secrets Manager
var connectionString = await AwsSecretsManagerHelper.GetSecretAsync(
    "Development_aws-secret-manager_ConnectionStrings__DefaultConnection",
    "eu-north-1"
);

// 🔹 Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Document}/{action=Index}/{id?}");

app.Run();
