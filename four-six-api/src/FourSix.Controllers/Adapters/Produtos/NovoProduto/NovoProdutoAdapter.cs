using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.NovoProduto
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class NovoProdutoAdapter : INovoProdutoAdapter
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        private readonly INovoProdutoUseCase _useCase;

        public NovoProdutoAdapter(Notification notification,
            INovoProdutoUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoProdutoResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoProdutoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task Inserir(NovoProdutoRequest produto)
        {
            await _useCase.Execute(produto.Nome, produto.Descricao, produto.Categoria, produto.Preco)
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}

