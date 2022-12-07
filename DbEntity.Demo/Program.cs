using DbEntity.Demo.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

// Create configuration from custom configuration file
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
    .Build();


// Add services to host
builder.ConfigureServices(services =>
{
    services.AddSingleton<IDbManager>(_ =>
    new SQLiteDbManager(config.GetValue<string>("ConnectionStrings:default")));
    services.AddSingleton<UserManager>();
});

// build application
using var app = builder.Build();
app.Start();

var userManager = app.Services.GetService<UserManager>()!;
var user = userManager.NewUser();
user.Name = "DarkMixer";
user.Email = "Hello@mail.dk";
user.Insert();
