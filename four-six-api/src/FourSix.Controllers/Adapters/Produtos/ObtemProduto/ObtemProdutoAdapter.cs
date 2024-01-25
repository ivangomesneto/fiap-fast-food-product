using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProduto
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    public class ObtemProdutoAdapter : IObtemProdutoAdapter
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        private readonly IObtemProdutoUseCase _useCase;

        public ObtemProdutoAdapter(Notification notification,
            IObtemProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        //[AllowAnonymous]
        //[HttpGet("{id:guid}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutoResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task Obter(Guid id)
        {
            await _useCase.Execute(id)
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}
