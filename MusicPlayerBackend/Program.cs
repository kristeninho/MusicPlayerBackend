using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicPlayerBackend.Data;
using MusicPlayerBackend.Repositories;
using MusicPlayerBackend.Repositories.Interfaces;
using System.Text;
using ConfigurationManager = MusicPlayerBackend.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For cloud DB
//builder.Services.AddPooledDbContextFactory<AppDbContext>(options
//    => options.UseSqlServer(ConfigurationManager.AzureConnectionStrings.GetConnectionString("Database")));

// For local DB
builder.Services.AddPooledDbContextFactory<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IAlbumRepository, AlbumRepository>();
builder.Services.AddSingleton<ISongRepository, SongRepository>();
builder.Services.AddSingleton<IAzureCloudStorageRepository, AzureCloudStorageRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "V1",
        Title = "WebAPI",
        Description = "MusicPlayer WebAPI"
    });
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options=>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = ConfigurationManager.AppSetting["JWT:ValidIssuer"],
            ValidAudience = ConfigurationManager.AppSetting["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "MusicPlayer WebAPI");
    });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.Run();
