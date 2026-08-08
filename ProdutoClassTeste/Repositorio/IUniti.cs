using ApiProduto.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoClassTeste.Repositorio
{
    public class IUniti
    {
        public  static ApiProduto.Domain.Interface.IUniti SaveChanges()
        {
            var mq= new Mock<ApiProduto.Domain.Interface.IUniti>();
            return mq.Object;
        }
    }
}
