using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data;
using Omar_Ahmed_0523006.RepostryPattern.CoachesRepos;
using Omar_Ahmed_0523006.RepostryPattern.ComptionRepos;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;
using Omar_Ahmed_0523006.RepostryPattern.PLayerRepos;
using Omar_Ahmed_0523006.RepostryPattern.TeamRepos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped(typeof(IGenricRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped(typeof(ICoachRepos), typeof(CoachRepos));
builder.Services.AddScoped(typeof(IPlayerRepos), typeof(PlayerRepos));
builder.Services.AddScoped(typeof(ITeamRepos), typeof(TeamRepos));
builder.Services.AddScoped(typeof(IComptionRepos), typeof(ComptionRepos));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
