using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProduto
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProdutosController : Controller
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

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get([FromRoute][Required] Guid id)
        {
            await _useCase.Execute(id)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
