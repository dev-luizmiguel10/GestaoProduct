using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProduto.Application.DTO
{
    public class ProdutoError
    {
        public List<string> Error { get; set; }

        public ProdutoError(List <string> Erromsg)
        {
            Error = Erromsg;
        }
        public ProdutoError(string erro)
        {
            Error= new List<string> { erro };
        }
    }
}
