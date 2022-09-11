using System.Text;
using Application.Interfaces;
using Application.Services;
using Infra.Data.DAL;
using Infra.Data.data;
using Infra.Data.IGenericRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentation.Auth;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;



// Add services to the container.
builder.Services.AddScoped<UnitOfWork>(); // Add UnitOfWork to Container
builder.Services.AddScoped<IAchieveReports, AchieveReports>(); //Add Application layer Interfaces to container
builder.Services.AddScoped<IScoreReports, ScoreReports>();
builder.Services.AddScoped<ISortingReports, SortReports>();
//Add IAsyncRepository
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
     options => options.UseSqlServer("name=ConnectionStrings:MyDb1"));
builder.Services.AddDbContext<applicationDbContext>(
     options => options.UseSqlServer("name=ConnectionStrings:MyDb1"));

     

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<applicationDbContext>()
.AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})// ادامه داره پایین

//Adding Jwt Bearer
.AddJwtBearer(options => 
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

    };
});


var app = builder.Build(); 


#region Pipelines 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();


app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.MapControllers();

#endregion

app.Run();
