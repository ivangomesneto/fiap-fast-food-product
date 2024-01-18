using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProdutos
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProdutosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IObtemProdutosUseCase _useCase;

        public ProdutosController(Notification notification,
            IObtemProdutosUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        /// <summary>
        /// Obtém todos os produtos
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutosResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutosResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get()
        {
            await _useCase.Execute()
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
