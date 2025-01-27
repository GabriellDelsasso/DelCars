using DelCars.Application.Interfaces;
using DelCars.Application.Services;
using DelCars.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        b => b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetPreflightMaxAge(TimeSpan.FromDays(30)));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarsApplicationService, CarsApplicationService>();
builder.Services.AddScoped<IRentCarApplicationService, RentCarApplicationService>();
builder.Services.ConfigurePostgre(builder.Configuration);
builder.Services.ConfigureDomain();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "DelCars API V1");
});

app.Run();
