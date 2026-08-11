using ApiProduto.Application.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace ProductTesteIntegration.Factory
{
    public class ProductFactory: IClassFixture<FactoryProduct>
    {
        private readonly HttpClient _http;
        public ProductFactory(FactoryProduct factory)
        {
            _http = factory.CreateClient();
        }

        [Fact]
        public async Task CadastrarProduto()
        {
            var novo_produto = new ProdutoDto
            {
                nome_produto = "Refrigerante",
                preco = 4.5m,
                qtd_estoque = 100
            };
            var response = await _http.PostAsJsonAsync("/api/Produto",
                novo_produto);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }


        [Fact]
        public async Task EditarProduto()
        {
            var produto_criado = new ProdutoDto
            {
                nome_produto = "Refrigerante Cola",
                preco = 5.0m,
                qtd_estoque = 80
            };
            var response = await _http.PostAsJsonAsync("/api/Produto/", produto_criado);
            var produto_salvo = await response.Content.ReadFromJsonAsync<ProdutoDto>();

            var produto_editado = new ProdutoDto
            {
                id = produto_salvo.id,
                nome_produto = "Refrigerante Cola Zero",
                preco = 6.7m,
                qtd_estoque = 90
            };
            
            var responses = await _http.PutAsJsonAsync($"/api/Produto/{produto_salvo!.id}", produto_editado);
            Assert.Equal(HttpStatusCode.OK, responses.StatusCode);
        }

        [Fact]
        public async Task DeletarProduto()
        {
            var produto_criado = new ProdutoDto
            {
                nome_produto = "Refrigerante Cola",
                preco = 5.55m,
                qtd_estoque = 80
            };
            var response = await _http.PostAsJsonAsync("/api/Produto/", produto_criado);
            var produto_salvo = await response.Content.ReadFromJsonAsync<ProdutoDto>();

            var responses = await _http.DeleteAsync($"/api/Produto/{produto_salvo!.id}");
            Assert.Equal(HttpStatusCode.NoContent, responses.StatusCode);
        }


        [Fact]
        public async Task ListaProdutoEspecefico()
        {
            var produto_criado = new ProdutoDto
            {
                nome_produto = "Refrigerante Cola",
                preco = 12.0m,
                qtd_estoque = 80
            };
            var response = await _http.PostAsJsonAsync("/api/Produto/", produto_criado);
            var produto_salvo = await response.Content.ReadFromJsonAsync<ProdutoDto>();

            var responses = await _http.GetAsync($"/api/Produto/{produto_salvo!.id}");
            Assert.Equal(HttpStatusCode.OK, responses.StatusCode);
        }



        [Fact]
        public async Task ListaProduto()
        {
            var produto_criado = new ProdutoDto
            {
                nome_produto = "Refrigerante Cola",
                preco = 20.0m,
                qtd_estoque = 80
            };
            var response = await _http.PostAsJsonAsync("/api/Produto/", produto_criado);
            var produto_salvo = await response.Content.ReadFromJsonAsync<ProdutoDto>();

            var responses = await _http.GetAsync($"/api/Produto/");
            Assert.Equal(HttpStatusCode.OK, responses.StatusCode);
        }
    }
}
