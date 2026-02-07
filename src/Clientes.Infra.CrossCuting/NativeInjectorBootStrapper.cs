using Clientes.Application;
using Clientes.Application.Interfaces;
using Clientes.Domain.Interfaces;
using Clientes.Infra.Data.Contexto;
using Clientes.Infra.Data.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Clientes.Infra.CrossCuting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositorio

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();


            #endregion

            #region Aplicacao

            services.AddScoped(typeof(IAppBase<,,>), typeof(AppBase<,,>));
            services.AddScoped<IClienteApp, ClienteApp>();
           

            #endregion

            services.AddScoped<ClienteDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

        }
    }

}
