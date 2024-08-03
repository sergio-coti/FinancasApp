using Microsoft.OpenApi.Models;

namespace FinancasApp.API.Extensions
{
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options => options.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "FinancasApp - API para controle de contas",
                    Description = "C# WebDeveloper - Formação Fullstack COTI Informática",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://wwww.cotiinformatica.com.br")
                    }
                })
                );

            return services;
        }
    }
}
