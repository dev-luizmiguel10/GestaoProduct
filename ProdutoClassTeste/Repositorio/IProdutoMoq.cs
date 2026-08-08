using ApiProduto.Domain.Entities;
using ApiProduto.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoClassTeste.Repositorio
{
    public class IProdutoMoq
    {
        public static IProdutoRepositorio AddProduct()
        {
            var moq= new Mock<IProdutoRepositorio>();
            Mock.Get(moq.Object).Setup(s=>s.AdcionarProduto(It.IsAny<ApiProduto.Domain.Entities.Produto>())).Returns(Task.CompletedTask);
            return moq.Object;
        }
        public static IProdutoRepositorio GetProductId()
        {
            var moq = new Mock<IProdutoRepositorio>();
            Mock.Get(moq.Object).Setup(s => s.GetProductId(It.IsAny<int>())).ReturnsAsync(new ApiProduto.Domain.Entities.Produto());
            return moq.Object;
        }
        public static IProdutoRepositorio ListaProdutos()
        {
            var moq = new Mock<IProdutoRepositorio>();
            Mock.Get(moq.Object).Setup(s => s.ListaProdutos()).ReturnsAsync(new List<ApiProduto.Domain.Entities.Produto>());
            return moq.Object;
        }
        public static IProdutoRepositorio EditarProduct()
        {
            var moq = new Mock<IProdutoRepositorio>();
            Mock.Get(moq.Object).Setup(s => s.EditarProduct(It.IsAny<int>(), It.IsAny<ApiProduto.Domain.Entities.Produto>()))
                .ReturnsAsync(new ApiProduto.Domain.Entities.Produto());
            return moq.Object;
        }
        public static IProdutoRepositorio DeleteProduct()
        {
            var moq = new Mock<IProdutoRepositorio>();
            Mock.Get(moq.Object).Setup(s => s.DeleteProduct(It.IsAny<int>())).Returns(Task.CompletedTask);
            return moq.Object;
        }
    }
}
