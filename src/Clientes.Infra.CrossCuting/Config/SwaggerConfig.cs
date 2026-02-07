using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;


namespace Clientes.Infra.CrossCuting.Config
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddSwaggerGen
            (
                s =>
                {
                    s.SwaggerDoc
                    (
                        "v1"

                        , new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "Cliente API",
                            Description = "API voltada para a gestão de Clientes",
                            Contact = new OpenApiContact
                            {

                                Email = string.Empty
                            }
                        }

                    );

                }
            );
        }

    }

}
