using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;
using Prometheus;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Exceptions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureLogging();
builder.Host.UseSerilog();
// Add services to the container.
DotNetEnv.Env.TraversePath().Load();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUtilityRepository, UtilityRepository>();



builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(builder =>
    {
        //    var origins = "https://localhost:44308;http://localhost:44308";

        // builder.AllowCredentials();
        // builder.SetIsOriginAllowed(origin => true);
        builder.WithOrigins("http://localhost:5000", "http://164.92.132.67:5000")
        .AllowAnyHeader()
        .AllowAnyMethod();
        // builder.AllowAnyMethod();
        // builder.AllowAnyHeader();
    });
});


var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).AddEnvironmentVariables().Build();
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("myDb1"));
});

var app = builder.Build();
// Use the Prometheus middleware
app.UseRouting();
// app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseMetricServer();
app.UseHttpMetrics();
// app.UseHttpsRedirection();
app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapMetrics();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();

void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
            optional: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}


ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
    };
}


