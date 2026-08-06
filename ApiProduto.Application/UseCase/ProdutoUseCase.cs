using ApiProduto.Application.DTO;
using ApiProduto.Domain.Entities;
using ApiProduto.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ApiProduto.Exception.Produtos;
namespace ApiProduto.Application.UseCase
{
    public class ProdutoUseCase : IProduto
    {
        private readonly IUniti _uniti;
        private readonly IProdutoRepositorio _prod;
        public ProdutoUseCase(IUniti uniti, IProdutoRepositorio prod)
        {
            _uniti = uniti;
            _prod = prod;
        }

        public async Task<ProdutoDto> CadastroProduto(ProdutoDto produto)
        {
            await ValidarProduto(produto);

            var add_produto = new Produto
            {
                nome_produto = produto.nome_produto,
                preco = produto.preco,
                qtd_estoque = produto.qtd_estoque,
            };
           
            await _prod.AdcionarProduto(add_produto);
            await _uniti.Save();

            return new ProdutoDto
            {
                nome_produto = add_produto.nome_produto,
                preco = add_produto.preco,
                qtd_estoque = add_produto.qtd_estoque
            };

        }
        public async Task ValidarProduto(ProdutoDto produto)
        {
            var pr = new ProdutoValidation();
            var result = await pr.ValidateAsync(produto);
            
            if (!result.IsValid)
                throw new ProdutoOnException(result.Errors.Select(e => e.ErrorMessage).ToList());
            
        }

        public async Task DeleteProduct(int id)
        {
            await _prod.DeleteProduct(id);
            await _uniti.Save();
        }

        public async Task<Produto> EditarProduct(int id, ProdutoDto produto )
        {
            Produto pr = new Produto
            {
                ProdutoId=id,
                preco = produto.preco,
                nome_produto = produto.nome_produto,
                qtd_estoque = produto.qtd_estoque,
            };

            var product = await _prod.EditarProduct(id, pr);
            product.preco = produto.preco;
            product.nome_produto = produto.nome_produto;
            product.qtd_estoque=produto.qtd_estoque;

            await _uniti.Save();
            return pr;
        }

        public async Task<Produto> GetProductId(int id)
        {
            return await _prod.GetProductId(id);
        }

        public async Task<List<Produto>> ListaProdutos()
        {
           var pr= await _prod.ListaProdutos();
            return pr;
        }
    }
}
