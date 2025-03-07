using TahalufAssignmentCore.Helpers.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using TahalufAssignmentCore.Context;
using TahalufAssignmentCore.Middlewares;
using TahalufAssignmentCore.Services;
using TahalufAssignmentInfrastructure.Services;
using Serilog;
using System.Text;
using TahalufAssignmentCore.Interfaces;
using TahalufAssignmentInfrastructure.Repositories;
using TahalufAssignmentCore.Mappers;
using TahalufAssignmentCore.Services.AppServices;
using TahalufAssignmentInfrastructure.Services.AppServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your token."
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSetting:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

//Configure Mail Settings
EmailSetting.Initialize(builder.Configuration);
TokenSetting.Initialize(builder.Configuration);
builder.Services.AddDbContext<TahalufAssignmentDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILookupTypeServices, LookupTypeServices>();
builder.Services.AddScoped<ILookupItemServices, LookupItemServices>();
builder.Services.AddScoped<IAuthanticationService, AuthanticationService>();
builder.Services.AddScoped<IOrganizationAppService, OrganizationAppService>();
builder.Services.AddScoped<ICompanyAppService, CompanyAppService>();
//Enabling With CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//Log File 
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).
                WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/log.txt"), rollingInterval: RollingInterval.Day).
                CreateLogger();
var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.UseSwagger();
app.UseSwaggerUI();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tahaluf Assignment API");
//    c.RoutePrefix = string.Empty;
//});

app.UseStaticFiles();
// Add custom static files middleware
var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesDirectory),
    RequestPath = "/Files"
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TokenAuthorizationMiddleware>();
app.MapControllers();

app.Run();
