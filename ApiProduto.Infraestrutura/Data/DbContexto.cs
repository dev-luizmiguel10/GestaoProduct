using ApiProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Infraestrutura.Data
{
    public class DbContexto:DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbContexto(DbContextOptions<DbContexto> options):base(options)
        {
        }
    }
}
