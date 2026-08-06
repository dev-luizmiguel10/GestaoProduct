using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Exception.Produtos
{
    public class ProdutoOnException:ProdutoException
    {
        public List<string> Errors { get; set; }

        public ProdutoOnException(List<string> erros)
        {
            Errors = erros;
        }
    }
}
