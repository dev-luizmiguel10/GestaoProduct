using ApiProduto.Domain.Entities;
using ApiProduto.Domain.Interface;
using ApiProduto.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Infraestrutura.Repositorio
{
    public class ProdutoRepository:IProdutoRepositorio
    {
        private readonly DbContexto _db;
        public ProdutoRepository(DbContexto dbContexto)
        {
            _db = dbContexto;
        }

        public async Task AdcionarProduto(Produto produto)
        {
             await _db.Produtos.AddAsync(produto);
        }

        public async Task DeleteProduct(int id)
        {
            var delete=await _db.Produtos.FirstOrDefaultAsync(s=>s.ProdutoId==id);
           _db.Produtos.Remove(delete);
        }

        public async Task<Produto> EditarProduct(int id,Produto produto)
        {
            var product= await _db.Produtos.FirstOrDefaultAsync(p=>p.ProdutoId == id);

            product.preco = produto.preco;
            product.nome_produto=produto.nome_produto;
            product.qtd_estoque=produto.qtd_estoque;
             _db.Produtos.Update(product);
            return produto;
           
        }

        public async Task<Produto> GetProductId(int id)
        {
           
            var pr= await _db.Produtos.FirstOrDefaultAsync(p=>p.ProdutoId==id);
            if (pr==null)
            {
                return null;
            }
            return pr;
        }

        public async Task<List<Produto>> ListaProdutos()
        {
            return  await _db.Produtos.ToListAsync();
        }
    }
}
