using FourSix.Application.Services;
using FourSix.Application.UseCases.Produtos.AlteraProduto;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Produtos.AlteraProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class ProdutosController : Controller, IOutputPort
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IAlteraProdutoUseCase _useCase;

        public ProdutosController(Notification notification,
            IAlteraProdutoUseCase useCase)
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
            this._viewModel = this.Ok(new AlteraProdutoResponse(new ProdutoModel(produto)));

        void IOutputPort.Exist() => this._viewModel = this.BadRequest("Produto já existe");

        /// <summary>
        /// Altera produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <param name="produto">Dados do Produto</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlteraProdutoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] AlteraProdutoRequest produto)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(produto.Nome, 
                produto.Descricao, 
                produto.Categoria,
                produto.Preco)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
