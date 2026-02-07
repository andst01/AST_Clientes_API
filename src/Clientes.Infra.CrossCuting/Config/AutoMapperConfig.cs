using Clientes.Infra.CrossCuting.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Clientes.Infra.CrossCuting.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMappingConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile),
                                   typeof(DTOToDomainMappingProfile));
        }
    }
}
