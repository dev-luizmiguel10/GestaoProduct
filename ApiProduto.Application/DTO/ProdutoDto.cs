using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Application.DTO
{
    public class ProdutoDto
    {
        public string nome_produto { get; set; }
        public decimal preco { get; set; }
        public int qtd_estoque { get; set; }
    }
}
