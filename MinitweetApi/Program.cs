using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;
using Mcrio.Configuration.Provider.Docker.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();



var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).AddDockerSecrets().AddEnvironmentVariables().Build();
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    options.UseNpgsql(config["ConnectionStrings__myDb1"]);
});


var app = builder.Build();


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
