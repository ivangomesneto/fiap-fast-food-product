using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.AlteraProduto
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Criar, Obter, Editar and Excluir Produtos")]
    public class AlteraProdutoAdapter : IAlteraProdutoAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IAlteraProdutoUseCase _useCase;

        public AlteraProdutoAdapter(Notification notification,
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
        //[AllowAnonymous]
        //[HttpPut("{id:guid}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraProdutoResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlteraProdutoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task Edit(Guid id, AlteraProdutoRequest produto)
        {
            await _useCase.Execute(id,
                produto.Nome,
                produto.Descricao,
                produto.Categoria,
                produto.Preco)
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}
