using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Repastories;
using Kitchen.Backend.Repastories.Account;
using Kitchen.Backend.Repastories.StudyRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAdminAccountService, AdminAccountService>();
builder.Services.AddTransient<IKitchenService, KitchenService>();

builder.Services.AddDbContext<KitchenDbContext>(option => 
option.UseNpgsql(builder.Configuration.GetConnectionString("KitchenConnection")));
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
