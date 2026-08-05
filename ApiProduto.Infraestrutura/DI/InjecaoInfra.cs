using ApiProduto.Domain.Interface;
using ApiProduto.Infraestrutura.Data;
using ApiProduto.Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Infraestrutura.DI
{
    public static class InjecaoInfra
    {
        public static void InfraInjecao(this IServiceCollection services, IConfiguration configuration)
        {
            Contexto(services, configuration);
            Repositorio(services);
        }
        public static void Contexto(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContexto>(u => u.UseSqlServer(configuration.GetConnectionString("Conection")));
        }
        public static void Repositorio(IServiceCollection services)
        {
            services.AddScoped<IUniti, UnitiRepository>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepository>();
           
        }
    }
}
