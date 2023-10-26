using FourSix.Application.Services;
using FourSix.Application.UseCases.Produtos.ObtemProdutoPorCategoria;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProdutoPorCategoria
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProdutosController : Controller, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        private readonly IObtemProdutoPorCategoriaUseCase _useCase;

        public ProdutosController(Notification notification,
            IObtemProdutoPorCategoriaUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(IList<Produto> produtos) =>
           this._viewModel = this.Ok(new ObtemProdutoPorCategoriaResponse(produtos.Select(s => new ProdutoModel(s)).ToList()));

        [AllowAnonymous]
        [HttpGet("{categoria}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutoPorCategoriaResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutoPorCategoriaResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get([FromRoute][Required] EnumCategoriaProduto categoria)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(categoria)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
