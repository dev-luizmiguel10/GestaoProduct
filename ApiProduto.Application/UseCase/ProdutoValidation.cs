using ApiProduto.Application.DTO;
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
            RuleFor(p => p.preco).NotNull().NotEmpty().WithMessage("Preco nao pode ser vazio");
            RuleFor(q=>q.qtd_estoque).NotNull().NotEmpty();
            RuleFor(n=>n.nome_produto).NotNull().NotEmpty();
        }
    }
}
