using backend.Configuration;
using backend.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentApi", Version = "v1" });
});
// Register MongoDB configuration
builder.Services.Configure<MongoDBConfiguration>(builder.Configuration.GetSection(nameof(MongoDBConfiguration)));

// Add MongoDbContext to the services
builder.Services.AddScoped<MongoDbContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
}
app.UseCors(
    options=>options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
);
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

