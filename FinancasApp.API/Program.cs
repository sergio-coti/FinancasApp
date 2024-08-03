using FinancasApp.API.Extensions;
using FinancasApp.Domain.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });
builder.Services.AddSwaggerDoc();
builder.Services.AddCorsConfig();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(typeof(ProfileMapping));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCorsConfig();

app.UseAuthorization();
app.MapControllers();
app.Run();
