using ApiProduto.Application.UseCase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Application.DI
{
    public static class InjecaoApp
    {
        public static void AppInjecao(this IServiceCollection service)
        {
            Repositorio(service);
        }
        public static void Repositorio(IServiceCollection services)
        {
            services.AddScoped<IProduto, ProdutoUseCase>();
        }
    }
}
