using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Produtos.InativaProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class ProdutosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IInativaProdutoUseCase _useCase;

        public ProdutosController(Notification notification,
            IInativaProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        /// <summary>
        /// Inativa produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            await _useCase.Execute(id)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
