using FourSix.Application.Services;
using FourSix.Application.UseCases.Produtos.NovoProduto;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Produtos.NovoProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class ProdutosController : Controller, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        private readonly INovoProdutoUseCase _useCase;

        public ProdutosController(Notification notification,
            INovoProdutoUseCase useCase)
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
            this._viewModel = this.Ok(new NovoProdutoResponse(new ProdutoModel(produto)));

        void IOutputPort.Exist() => this._viewModel = this.BadRequest("Produto já existe");

        [AllowAnonymous]
        [HttpPut("/novo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlteraProdutoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<IActionResult> Novo([FromBody] NovoProdutoRequest request)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(request.produto)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }



}
}
