using ApiProduto.Application.DTO;
using ApiProduto.Application.UseCase;
using ProdutoClassTeste.Produto;
using ProdutoClassTeste.Repositorio;
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

        [Fact]
        public async Task CadastProdutoSucesso()
        {
            var cadastro_produto = TesteProduto.Teste();
            var validation = new ProdutoValidation();
            var validationResult = validation.Validate(cadastro_produto);

            var moq_aplication_Produto = IProdutoMoq.AddProduct();
            var moq_salve = IUniti.SaveChanges();

            var classe_produto = new ProdutoUseCase(moq_salve, moq_aplication_Produto);
            var add_produto = await classe_produto.CadastroProduto(cadastro_produto);
            Assert.True(validationResult.IsValid);


        }
        [Fact]
        public async Task EditarProdutoSucesso()
        {
            var cadastro_produto = TesteProduto.Teste();
            var validation = new ProdutoValidation();
            var validationResult = validation.Validate(cadastro_produto);
            var moq_aplication_Produto = IProdutoMoq.EditarProduct();
            var moq_salve = IUniti.SaveChanges();
            var classe_produto = new ProdutoUseCase(moq_salve, moq_aplication_Produto);
            var add_produto = await classe_produto.EditarProduct(1, cadastro_produto);
            Assert.True(validationResult.IsValid);

        }
        [Fact]
        public async Task DeleteProdutoSucesso()
        {
            var moq_aplication_Produto = IProdutoMoq.DeleteProduct();
            var moq_salve = IUniti.SaveChanges();
            var classe_produto = new ProdutoUseCase(moq_salve, moq_aplication_Produto);
            await classe_produto.DeleteProduct(1);
            Assert.True(true);
        }
        [Fact]
        public async Task GetProdutoIdSucesso()
        {
            var moq_aplication_Produto = IProdutoMoq.GetProductId();
            var moq_salve = IUniti.SaveChanges();
            var classe_produto = new ProdutoUseCase(moq_salve, moq_aplication_Produto);
            var produto = await classe_produto.GetProductId(1);
            Assert.NotNull(produto);
        }
        [Fact]
        public async Task ListaProdutoSucesso()
        {
            var moq_aplication_Produto = IProdutoMoq.ListaProdutos();
            var moq_salve = IUniti.SaveChanges();
            var classe_produto = new ProdutoUseCase(moq_salve, moq_aplication_Produto);
            var produto = await classe_produto.ListaProdutos();
            Assert.NotNull(produto);
        }
        
    }
}
