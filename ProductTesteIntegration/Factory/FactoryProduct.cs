using ApiProduto.Infraestrutura.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTesteIntegration.Factory
{
    public class FactoryProduct:WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.Where(d => d.ServiceType == typeof(DbContextOptions<DbContexto>)
                || d.ServiceType == typeof(DbContextOptions)).ToList();

                foreach (var item in descriptor)
                {
                    services.Remove(item);
                }
                var sql_provdier=services.Where(d=>d.ServiceType==typeof(IDbContextOptionsConfiguration<DbContexto>)).ToList();
                foreach (var item in sql_provdier)
                {
                    services.Remove(item);
                }
                services.AddDbContext<DbContexto>(options =>
                {
                    options.UseInMemoryDatabase("Db_ProductInMemory");
                });
            });
        }
    }
}
