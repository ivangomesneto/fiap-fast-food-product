using FourSix.Application.Services;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.NegaPagamento
{
    public class NegaPagamentoValidationUseCase : INegaPagamentoUseCase
    {
        private readonly Notification _notification;
        private readonly INegaPagamentoUseCase _useCase;
        private IOutputPort<Pagamento> _outputPort;

        public NegaPagamentoValidationUseCase(INegaPagamentoUseCase useCase, Notification notification)
        {
            _useCase = useCase;
            _notification = notification;
            _outputPort = new NegaPagamentoPresenter();
        }

        public void SetOutputPort(IOutputPort<Pagamento> outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid pagamentoId)
        {
            if (_notification
            .IsInvalid)
            {
                _outputPort
                    .Invalid();
                return;
            }

            await _useCase
                .Execute(pagamentoId)
                .ConfigureAwait(false);
        }
    }
}
