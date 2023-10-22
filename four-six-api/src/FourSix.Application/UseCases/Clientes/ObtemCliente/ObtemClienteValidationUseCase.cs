using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Clientes.ObtemCliente
{
    public class ObtemClienteValidationUseCase : IObtemClienteUseCase
    {
        private readonly Notification _notification;
        private readonly IObtemClienteUseCase _useCase;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountValidationUseCase" /> class.
        /// </summary>
        public ObtemClienteValidationUseCase(IObtemClienteUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new ObtemClientePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                this._notification
                    .Add(nameof(cpf), $"{nameof(cpf)} é obrigatório");
            }

            if (this._notification
                .IsInvalid)
            {
                this._outputPort.Invalid();
                return;
            }

            await this._useCase
                .Execute(cpf)
                .ConfigureAwait(false);
        }
    }
}
