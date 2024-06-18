using Astra.BLL.Interfaces;
using Astra.BLL.Services;
using Astra.DAL.DataAccess;
using Astra.DAL.Repositories;
using AstraAPI.Controllers;
using AstraAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Authentification
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("tokenInfo").GetSection("secretKey").Value)),
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidAudience = "http://localhost:8100" 
        };
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("connectedPolicy", policy => policy.RequireAuthenticatedUser());
});

#endregion

builder.Services.AddSignalR();

builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("home")));

builder.Services.AddScoped<JwtGenerator>();
builder.Services.AddScoped<IUserBLLService,UserBLLService>();
builder.Services.AddScoped<IUserRepository, UserService>();

builder.Services.AddScoped<IPostBLLService, PostBLLService>();
builder.Services.AddScoped<IPostRepository, PostService>();

builder.Services.AddCors(o => o.AddPolicy("front", options =>
    options.WithOrigins("http://localhost:8100") // Ajoutez l'URL de votre application Angular ici
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
           .WithExposedHeaders("Content-Disposition")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("front");
app.UseHttpsRedirection();
app.MapHub<ChatHub>("chat-hub");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
