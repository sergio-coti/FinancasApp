namespace FinancasApp.API.Extensions
{
    public static class CorsConfigExtension
    {
        #region Atributos

        private static string _name = "DefaultPolicy";
        private static string[] _origins = {
            "http://localhost:4200"
        };

        #endregion

        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(_name, policy => {
                    policy.WithOrigins(_origins).AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(_name);
            return app;
        }
    }
}
