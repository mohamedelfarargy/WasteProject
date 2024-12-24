using BuissnesLogic.AutoMapeer;
using BuissnesLogic.Implemntation;
using BuissnesLogic.ServiceIntrface;
using DataAcsessLayer.Data;
using DataAcsessLayer.Entity;
using DataAcsessLayer.Implemention;
using DataAcsessLayer.repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplactionDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserReposatory, UserRepostaroy>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<ICollectorService, CollectorService>();
builder.Services.AddScoped<IRepository<Collector>, CollectorReposatory>();
builder.Services.AddScoped<IWasteTypeService, WasteTypeService>();
builder.Services.AddScoped<IWasteTypeReposatory, WasteTypeReposatory>();
builder.Services.AddScoped<IRecyclingRequestService, RecyclingRequestService>();
builder.Services.AddScoped<IRecyclingRequestReposatory, RecyclingRequestReposatory>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:61448",
            ValidAudience = "http://localhost:61448",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VeryLongComplexSecretKey_@2024SecureKey1234567890!"))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddIdentity<User, IdentityRole<int>>()
        .AddEntityFrameworkStores<ApplactionDbcontext>()
        .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://your-frontend-domain.com") // استبدل هذا بدومين الفرونت-إند
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
