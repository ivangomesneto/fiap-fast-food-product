using FourSix.Application.Services;
using FourSix.Application.UseCases.Clientes.ObtemCliente;
using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FourSix.WebApi.UseCases.Clientes.ObtemCliente
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClientesController : Controller, IOutputPort
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IObtemClienteUseCase _useCase;

        public ClientesController(Notification notification,
            IObtemClienteUseCase useCase)
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
            this._viewModel = this.Ok(new ObtemClienteResponse(new ClienteModel(cliente)));


        /// <summary>
        /// Obtém cliente
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemClienteResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemClienteResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Get([FromRoute][Required] string cpf)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(cpf)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
