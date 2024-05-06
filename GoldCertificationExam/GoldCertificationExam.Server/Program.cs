using GoldCertificationExam.Server.Authentication;
using GoldCertificationExam.Server.Contexts;
using GoldCertificationExam.Server.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Jwt:issuer"];
    options.Audience = builder.Configuration["Jwt:audience"];
    options.RequireHttpsMetadata = false;
});
builder.Services.AddScoped<IAuthRepository, AuthRepositoryImpl>();
builder.Services.AddScoped<IBookRepository, BookRepositoryImp>();


builder.Services.AddCors((e) => {
    e.AddDefaultPolicy(builder => {
        builder.WithOrigins(
                "https://localhost:4200"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors();
JwtTokenGeneration.Secret_key = builder.Configuration["Jwt:key"];


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.UseAuthentication();


app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
