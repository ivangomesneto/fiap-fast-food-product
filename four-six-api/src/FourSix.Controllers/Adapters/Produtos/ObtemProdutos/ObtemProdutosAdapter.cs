using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutos
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    public class ObtemProdutosAdapter : IObtemProdutosAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IObtemProdutosUseCase _useCase;

        public ObtemProdutosAdapter(Notification notification,
            IObtemProdutosUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        ///// <summary>
        ///// Obtém todos os produtos
        ///// </summary>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutosResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutosResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task Get()
        {
            await _useCase.Execute()
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}
