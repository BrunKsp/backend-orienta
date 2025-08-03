using api.Extensions;
using ConfigurationSubstitution;
using Orienta.API.Configurations;
using Orienta.Application;
using Orienta.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

EnvironmentsConfig.Load();
builder.Configuration.EnableSubstitutions();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SwaggerServiceConfig();


builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(ExceptionFilter));
    //opt.Filters.Add(typeof(ValidacaoUsuarioFilter));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AuthServiceConfig(builder.Configuration);

var app = builder.Build();

app.AuthAppConfig();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
