using FourSix.Application.Services;
using FourSix.Application.UseCases.Clientes.NovoCliente;
using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Clientes.NovoCliente
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Editar and Excluir Clientes")]
    public class ClientesController : Controller, IOutputPort
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

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Cliente cliente) =>
            this._viewModel = this.Ok(new NovoClienteResponse(new ClienteModel(cliente)));

        void IOutputPort.Exist() => this._viewModel = this.BadRequest("Cliente já existe");

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
            _useCase.SetOutputPort(this);

            await _useCase.Execute(cliente.Cpf, cliente.NomeCompleto, cliente.Email)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
