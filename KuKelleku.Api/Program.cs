using Kukelleku.api.Configuration;
using Kukelleku.Api.Middleware;
using Kukelleku.Interfaces.Configuration;
using Kukelleku.Services.Startup;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddHttpClient();

// Bind the configuration to the NewsConfiguration class
NewsConfiguration newsConfiguration = new();
builder.Configuration.GetSection("News").Bind(newsConfiguration);
builder.Services.AddSingleton<INewsConfiguration>(newsConfiguration);

// Register the services
builder.RegisterServices();

var app = builder.Build();

// Add middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
