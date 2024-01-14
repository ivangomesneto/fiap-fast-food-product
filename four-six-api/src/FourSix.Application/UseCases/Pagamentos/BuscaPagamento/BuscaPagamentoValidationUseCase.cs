using FourSix.Application.Services;
using FourSix.Application.UseCases.Pagamentos.CancelaPagamento;
using FourSix.Domain.Entities.PagamentoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSix.Application.UseCases.Pagamentos.BuscaPagamento
{

    public class BuscaPagamentoValidationUseCase : IBuscaPagamentoUseCase
    {
        private readonly Notification _notification;
        private readonly IBuscaPagamentoUseCase _useCase;
        private IOutputPort<Pagamento> _outputPort;

        public BuscaPagamentoValidationUseCase(IBuscaPagamentoUseCase useCase, Notification notification)
        {
            _useCase = useCase;
            _notification = notification;
            _outputPort = new CancelaPagamentoPresenter();
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
