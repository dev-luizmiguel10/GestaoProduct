using ApiProduto.Application.DTO;
using ApiProduto.Exception.Produtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Application.UseCase
{
    public class ProdutoValidation:AbstractValidator<ProdutoDto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.preco).NotNull().NotEmpty().WithMessage(Produtos.Preco);
            RuleFor(q=>q.qtd_estoque).NotNull().GreaterThan(1).WithMessage(Produtos.Estoque);
            RuleFor(n=>n.nome_produto).NotNull().NotEmpty().WithMessage(Produtos.Nome_Produto);
        }
    }
}
