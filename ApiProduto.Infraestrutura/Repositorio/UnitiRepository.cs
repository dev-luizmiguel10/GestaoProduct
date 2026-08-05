using ApiProduto.Domain.Interface;
using ApiProduto.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Infraestrutura.Repositorio
{
    public class UnitiRepository:IUniti
    {
        private readonly DbContexto _db;
        public UnitiRepository(DbContexto db)
        {
            _db = db;
        }

        public Task Save()
        {
             return _db.SaveChangesAsync();
        }
    }
}
