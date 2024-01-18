using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Clientes.NovoCliente;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Clientes.NovoCliente
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Clientes")]
    public class ClientesController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly INovoClienteUseCase _useCase;

        public ClientesController(Notification notification,
            INovoClienteUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        /// <summary>
        /// Cria novo cliente
        /// </summary>
        /// <param name="cliente">Dados do Cliente</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoClienteResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] NovoClienteRequest cliente)
        {
            await _useCase.Execute(cliente.Cpf, cliente.NomeCompleto, cliente.Email)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
