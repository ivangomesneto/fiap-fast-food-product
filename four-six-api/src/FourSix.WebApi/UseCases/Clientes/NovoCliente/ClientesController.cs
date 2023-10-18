using FourSix.Application.Services;
using FourSix.Application.UseCases.Clientes.NovoCliente;
using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.WebApi.UseCases.Clientes.NovoCliente
{
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


        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoClienteResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
#pragma warning disable SCS0016 // Controller method is potentially vulnerable to Cross Site Request Forgery (CSRF).
        public async Task<IActionResult> Post(ClienteModel model)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(model.Cpf, model.Nome, model.Email)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
