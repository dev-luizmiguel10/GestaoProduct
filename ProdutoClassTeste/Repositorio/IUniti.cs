using ApiProduto.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoClassTeste.Repositorio
{
    public class IUniti
    {
        public  static IUniti Save()
        {
            var mq= new Mock<IUniti>();
            return mq.Object;
        }
    }
}
