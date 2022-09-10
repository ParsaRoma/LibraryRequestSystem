using Application.Interfaces;
using Application.Services;
using Infra.Data.DAL;
using Infra.Data.data;
using Infra.Data.IGenericRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
     options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

var app = builder.Build();


#region Pipelines 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.MapControllers();

#endregion

app.Run();
