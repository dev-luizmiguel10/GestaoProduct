using ApiProduto.Application.UseCase;
using ProdutoClassTeste.Produto;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteProductUnitario.Produto
{
    public class TestarProduto
    {
        [Fact]
        public void Sucesso()
        {
            var cadastro = TesteProduto.Teste();
            var result = new ProdutoValidation();

            var validationResult = result.Validate(cadastro);

            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void Nome_Produto_Vazio()
        {
            var cadastro = TesteProduto.Teste();
            cadastro.nome_produto = string.Empty;
            var result = new ProdutoValidation();
            Assert.True(result.Validate(cadastro).IsValid);
        }
        [Fact]
        public void QTD_Estoque_Vazio()
        {
            var cadastro = TesteProduto.Teste();
            cadastro.qtd_estoque = 0;
            var result = new ProdutoValidation();
            Assert.True(result.Validate(cadastro).IsValid);
        }
        [Fact]
        public void Preco_Produto_Vazio()
        {
            var cadastro = TesteProduto.Teste();
            cadastro.preco = 0;
            var result = new ProdutoValidation();
            Assert.True(result.Validate(cadastro).IsValid);
        }
    }
}
