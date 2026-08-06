using ApiProduto.Application.DTO;
using ApiProduto.Application.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace ApíProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _prod;
        public ProdutoController(IProduto produto)
        {
            _prod = produto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProdutoError),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraProduto( [FromBody]ProdutoDto produto)
        {
            await _prod.CadastroProduto(produto);
            return Created(string.Empty, produto);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
           var lista_produto= await _prod.ListaProdutos();
            return Ok(lista_produto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetId(int id)
        {
           var pr= await _prod.GetProductId(id);
            return Ok(pr);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarProduct(int id, [FromBody] ProdutoDto produto)
        {
            var pr = await _prod.EditarProduct(id,produto);
            return Ok(pr);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Delete(int id) {
            
            await _prod.DeleteProduct(id);
            return NoContent();
        }
    }
}
