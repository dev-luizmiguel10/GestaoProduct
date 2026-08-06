using ApiProduto.Application.DTO;
using ApiProduto.Exception.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace ApíProduto.Excption
{
    public class ExceptionFiltros : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProdutoException)
            {
                ValidarCadastroProduto(context);
            }
            else
            {
                ErrosDoServidorInterno(context);
            }
        }
        public void ValidarCadastroProduto(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ProdutoOnException ex:
                    context.Result = new BadRequestObjectResult(new ProdutoError(ex.Errors));
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

            }
        }
        public void ErrosDoServidorInterno(ExceptionContext context)
        {

            context.Result = new ObjectResult(new ProdutoError("Ocorreu um erro inesperado."));
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        }


    }
}
