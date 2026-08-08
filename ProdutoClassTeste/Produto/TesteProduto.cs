using ApiProduto.Application.DTO;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoClassTeste.Produto
{
    public class TesteProduto
    {
        public static ProdutoDto Teste()
        {
           return new Faker<ProdutoDto>()
                .RuleFor(p => p.nome_produto, f => f.Commerce.ProductName())
                .RuleFor(p => p.preco, f => f.Random.Decimal(1, 100))
                .RuleFor(p => p.qtd_estoque, f => f.Random.Int(1, 100))
                .Generate();
        }
    }
}
