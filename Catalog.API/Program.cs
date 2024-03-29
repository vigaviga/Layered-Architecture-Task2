using Catalog.Application;
using Layered_Architecture_Task2;
using Catalog.DataAccessLayer.EFCore;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Catalog.Kafka.Client;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEfCoreDAL();
builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection("Kafka"));
builder.Services.Configure<SchemaRegistryConfig>(builder.Configuration.GetSection("SchemaRegistry"));
builder.Services.AddApplicationLayerServices();
builder.Services.AddKafkaServices();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = "https://localhost:5001/resources",
            ValidateIssuer = true,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });

    options.AddPolicy("ManagerOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "verification");
        policy.RequireRole("manager");
    });
});

builder.Services.AddAutoMapper(typeof(ApiDomainMappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
