using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Security;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.Infra.Data.Repositories;
using FinancasApp.Infra.Security.Services;
using FinancasApp.Infra.Security.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do CORS para dar permiss�o ao projeto Blazor
builder.Services.AddCors(
    config => config.AddPolicy("DefaultPolicy", builder => {
        builder.WithOrigins("http://localhost:5227")
               .AllowAnyMethod()
               .AllowAnyHeader();
    })
);

// Configura��o para inje��o de depend�ncia para os servi�os do dom�nio
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<ICategoriaDomainService, CategoriaDomainService>();
builder.Services.AddTransient<IContaDomainService, ContaDomainService>();

// Configura��o para inje��o de depend�ncia para os reposit�rios
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IContaRepository, ContaRepository>();

//Configurar a inje��o de depend�ncia para a infraestrutura de seguran�a
builder.Services.AddTransient<ITokenSecurityService, TokenSecurityService>();

//Configura��es para autentica��o com JWT - JSON WEB TOKENS
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(JwtTokenSettings.SecretKey))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

//registrando a pol�tica do CORS
app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
