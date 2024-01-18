using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Produtos.NovoProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class ProdutosController : Controller
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

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoProdutoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] NovoProdutoRequest produto)
        {
            await _useCase.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}

