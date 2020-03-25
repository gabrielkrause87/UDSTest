using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDS.Data.Context;
using UDS.Data.Repository;
using UDS.Business.Services;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Interfaces.Services;
using UDS.Business.Interfaces;
using UDS.Business.Notificacoes;
using UDS.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using UDS.Api.Configs;

namespace UDS.Api
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IAcaiRepository, AcaiRepository>();
            services.AddScoped<IAcaiService, AcaiService>();

            services.AddScoped<ISaboresRepository, SaboresRepository>();
            services.AddScoped<ISaboresService, SaboresService>();

            services.AddScoped<ITamanhosRepository, TamanhosRepository>();
            services.AddScoped<ITamanhosService, TamanhosService>();

            services.AddScoped<IPersonalizacoesRepository, PersonalizacoesRepository>();
            services.AddScoped<IPersonalizacoesService, PersonalizacoesService>();

            services.AddScoped<IPedidosPersonalizacoesRepository, PedidosPersonalizacoesRepository>();
            services.AddScoped<IPedidosPersonalizacoesService, PedidosPersonalizacoesService>();

            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IPedidosService, PedidosService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
