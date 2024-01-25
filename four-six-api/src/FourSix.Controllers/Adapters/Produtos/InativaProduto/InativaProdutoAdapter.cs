using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.InativaProduto
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class InativaProdutoAdapter : IInativaProdutoAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IInativaProdutoUseCase _useCase;

        public InativaProdutoAdapter(Notification notification,
            IInativaProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        ///// <summary>
        ///// Inativa produto
        ///// </summary>
        ///// <param name="id">Id do produto</param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpDelete("{id:guid}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task Inativar(Guid id)
        {
            await _useCase.Execute(id)
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}
