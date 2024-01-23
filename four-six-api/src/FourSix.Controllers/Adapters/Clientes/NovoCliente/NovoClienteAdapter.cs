using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Clientes.NovoCliente;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Clientes.NovoCliente
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Criar, Obter, Editar and Excluir Clientes")]
    public class NovoClienteAdapter : INovoClienteAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly INovoClienteUseCase _useCase;

        public NovoClienteAdapter(Notification notification,
            INovoClienteUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        ///// <summary>
        ///// Cria novo cliente
        ///// </summary>
        ///// <param name="cliente">Dados do Cliente</param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoClienteResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoClienteResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task Inserir(NovoClienteRequest cliente)
        {
            await _useCase.Execute(cliente.Cpf, cliente.NomeCompleto, cliente.Email)
                .ConfigureAwait(false);

            //return _viewModel!;
        }
    }
}
