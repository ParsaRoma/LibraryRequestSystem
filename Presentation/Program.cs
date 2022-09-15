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
using Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();

//Add IAsyncRepository

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
.AddEntityFrameworkSqlServer()
.AddDbContext<ApplicationDbContext>(
     (sp, options) => options.UseSqlServer(builder.Configuration.GetConnectionString("default")).UseApplicationServiceProvider(sp));



// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();




// Add services to the container.
builder.Services.AddScoped<UnitOfWork>(); // Add UnitOfWork to Container
builder.Services.AddScoped<IAchieveReports, AchieveReports>(); //Add Application layer Interfaces to container
builder.Services.AddScoped<IScoreReports, ScoreReports>();
builder.Services.AddScoped<ISortingReports, SortReports>();

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
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

    };
});

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("Master", policy => policy.RequireClaim("master")); 
});



var app = builder.Build();


#region Pipelines 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// Authentication & Authorization
app.UseStaticFiles();
// app.UseCookiePolicy();
app.UseRouting();
// app.UseRequestLocalization();
// app.UseCors();
app.UseAuthentication();
app.UseAuthorization();





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

#endregion
using (var scope = app.Services.CreateScope())
{
    var unitOfWork = scope.ServiceProvider.GetService<UnitOfWork>();
    
}
app.Run();
