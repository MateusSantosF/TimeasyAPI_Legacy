using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.Text;
using TimeasyAPI.Controllers.Middlewares;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.RegisterDependencies();


// JWT 
var appSettings = new AppSettings();
builder.Configuration.GetSection("AppSettings").Bind(appSettings);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.TokenConfiguration.SecretJwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Configure Database Connection

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
app.UseAuthentication();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
