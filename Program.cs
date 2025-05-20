using Employee_Management_API.AutoMapper;
using Employee_Management_API.Interface;
using Employee_Management_API.Models;
using Employee_Management_API.Repository;
using Employee_Management_API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection to mssql
builder.Services.AddDbContext<EmployeeManagementApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagementApiContext") ?? throw new InvalidOperationException("Connection string 'EmployeeManagementApiContext' not found.")));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//HttpClient
builder.Services.AddHttpClient();


//Authentication and Authorization

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<EmployeeManagementApiContext>()
//    .AddDefaultTokenProviders();



//var jwtSettings = builder.Configuration.GetSection("JwtSettings");
//var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        //IssuerSigningKey = key,
//        ValidateIssuer = true,
//       // ValidIssuer = jwtSettings["Issuer"],
//        ValidateAudience = true,
//       // ValidAudience = jwtSettings["Audience"],
//        ValidateLifetime = true,
//        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//        ValidAudience = builder.Configuration["JwtSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
//        ClockSkew = TimeSpan.Zero
//    };
//});


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your_Secret_Key_Here"))
//    };
//});


//XML

builder.Services.AddControllers().AddXmlSerializerFormatters();

//Scoped
builder.Services.AddScoped<IEmployee, EmployeeRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EmployeeMapper));




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

// Use CORS
app.UseCors("AllowAll");



app.Run();
