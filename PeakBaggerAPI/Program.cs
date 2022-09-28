using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var sqlConBuilder = new SQLiteConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
//sqlConBuilder.UserID = builder.Configuration["UserId"];
//sqlConBuilder.Password= builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddScoped<IPeakRepo, SQLPeakRepo>();
builder.Services.AddScoped<IAreaRepo, SQLAreaRepo>();
builder.Services.AddScoped<ICountryRepo, SQLCountryRepo>();
builder.Services.AddScoped<ITagRepo, SQLTagRepo>();
builder.Services.AddScoped<ITrigPointTypeRepo, SQLTrigPointTypeRepo>();
builder.Services.AddScoped<IBaggedRepo, SQLBaggedRepo>();


builder.Services.AddControllers().AddNewtonsoftJson(s => {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
} 

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
