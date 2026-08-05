using ApiProduto.Application.DTO;
using ApiProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Application.UseCase
{
    public interface IProduto
    {
        public Task<Produto> CadastroProduto(ProdutoDto produto);
        Task<Produto> GetProductId(int id);
        Task<List<Produto>> ListaProdutos();
        Task<Produto> EditarProduct(int id, ProdutoDto produto);
        Task DeleteProduct(int id);
    }
}
