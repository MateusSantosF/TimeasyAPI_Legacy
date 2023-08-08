using Microsoft.EntityFrameworkCore;

using TimeasyAPI.Controllers.Middlewares;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models.UI;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database Connection
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//var connection = builder.Configuration.GetConnectionString(nameof(TimeasyDbContext));

//builder.Services.AddDbContext<TimeasyDbContext>(options =>
//    options.UseMySql(connection, ServerVersion.AutoDetect(connection))
//);

// Configure Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.File("log.txt",
        LogEventLevel.Warning,
        rollingInterval: RollingInterval.Day)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
    x.AllowAnyOrigin()    
);

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
