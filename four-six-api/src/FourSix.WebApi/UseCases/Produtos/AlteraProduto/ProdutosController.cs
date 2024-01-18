using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Produtos.AlteraProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class ProdutosController : Controller
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
            await _useCase.Execute(id,
                produto.Nome,
                produto.Descricao,
                produto.Categoria,
                produto.Preco)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
