using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorTipo
{
    // entender onde isso é usado.
    public class ObtemProdutoPorTipoValidationUseCase : IObtemProdutoPorTipoUseCase
    {
        private readonly Notification _notification;
        private readonly IObtemProdutoPorTipoUseCase _useCase;
        private IOutputPort _outputPort;

        public ObtemProdutoPorTipoValidationUseCase(IObtemProdutoPorTipoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new ObtemProdutoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute()
        {
            await this._useCase
                .Execute()
                .ConfigureAwait(false);
        }
    }
}
