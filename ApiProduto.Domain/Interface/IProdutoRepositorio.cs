using ApiProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Domain.Interface
{
    public interface IProdutoRepositorio
    {
        Task AdcionarProduto( Produto produto);
        Task<Produto> GetProductId(int id);
        Task<List<Produto>> ListaProdutos();
        Task<Produto> EditarProduct(int id,Produto produto);
        Task DeleteProduct(int id); 
    }
}
