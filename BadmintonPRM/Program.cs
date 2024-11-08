using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using Microsoft.OpenApi.Models;
using Repository.Base;
using Repository.Infrastructure;
using Service.Services;
using Service.Utils;
using MapperlyMapper = Service.Mapper.MapperlyMapper;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using BadmintonPRM.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins,
    policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        //.AllowCredentials();
    });
});

// Add serilog and get configuration from appsettings.json
builder.Services.AddSerilog(config => { config.ReadFrom.Configuration(builder.Configuration); });

// memory cache 
builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "AddAuthorization",
        Description = "Give me bearer token to call API here!",
        Type = SecuritySchemeType.Http
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();

//Add controllers
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();

// Add DI
builder.Services.AddScoped<MapperlyMapper>();
// Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
// Service
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<YardService>();
builder.Services.AddScoped<SlotService>();
builder.Services.AddScoped<BookingOrderService>();
builder.Services.AddScoped<YardImageService>();

// Add authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.UseSecurityTokenValidators = true;
        options.TokenValidationParameters = JwtUtils.GetTokenValidationParameters();
    });

// Add Authorization
builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("RequireAdminRole", policy => policy.RequireRole("1"));
    cfg.AddPolicy("RequireStaffRole", policy => policy.RequireRole("2"));
    cfg.AddPolicy("RequireOwnerRole", policy => policy.RequireRole("3"));
    cfg.AddPolicy("RequireCustomerRole", policy => policy.RequireRole("4"));
});

// Add OData
builder.Services.AddControllers();

//-----------------------------------------------------------------------------------------------
var app = builder.Build();
// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Apply any pending migrations
    dbContext.Database.Migrate();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors(myAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
