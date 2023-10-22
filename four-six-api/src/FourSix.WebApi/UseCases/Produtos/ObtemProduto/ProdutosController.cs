using FourSix.Application.Services;
using FourSix.Application.UseCases.Produtos.ObtemProduto;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProdutosController : Controller, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        private readonly IObtemProdutoUseCase _useCase;

        public ProdutosController(Notification notification,
            IObtemProdutoUseCase useCase)
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

        void IOutputPort.Ok(Produto produto) =>
            this._viewModel = this.Ok(new ObtemProdutoResponse(new ProdutoModel(produto));

        [AllowAnonymous]
        [HttpGet("{id}")]
        // entender isso
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get([FromRoute][Required] string id)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(id)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
