using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DotNetEnv.Env.TraversePath().Load();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUtilityRepository, UtilityRepository>();

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).AddEnvironmentVariables().Build();
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("myDb1"));
});


var app = builder.Build();

var counter = Metrics.CreateCounter("peopleapi_path_counter", "Counts requests to the People API endpoints");

/*app.Use((context, next) =>
{
    counter.Inc();
    Console.WriteLine("counter: " + counter.Value);
    return next();
});*/

Console.WriteLine("incrementing");
counter.Inc();

// Use the Prometheus middleware
app.UseMetricServer();
app.UseHttpMetrics();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();