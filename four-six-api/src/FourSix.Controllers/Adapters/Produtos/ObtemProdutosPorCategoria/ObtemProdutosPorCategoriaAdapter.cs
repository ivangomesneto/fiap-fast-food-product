using FourSix.Controllers.Presenters;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    public class ObtemProdutosPorCategoriaAdapter : IObtemProdutosPorCategoriaAdapter
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        private readonly IObtemProdutosPorCategoriaUseCase _useCase;

        public ObtemProdutosPorCategoriaAdapter(Notification notification,
            IObtemProdutosPorCategoriaUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        //[AllowAnonymous]
        //[HttpGet("{categoria}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemProdutoPorCategoriaResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemProdutoPorCategoriaResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task Get(EnumCategoriaProduto categoria)
        {
            await _useCase.Execute(categoria)
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}
