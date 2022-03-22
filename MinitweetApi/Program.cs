using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DotNetEnv.Env.TraversePath().Load();

// var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUtilityRepository, UtilityRepository>();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//                       builder =>
//                       {
//                           builder.WithOrigins("http://localhost/",
//                                               "http://68.183.67.47/");
//                       });
// });


var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).AddEnvironmentVariables().Build();
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("myDb1"));
});

var app = builder.Build();

// Use the Prometheus middleware
app.UseRouting();
// app.UseCors(MyAllowSpecificOrigins);
app.UseMetricServer();
app.UseHttpMetrics();

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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();