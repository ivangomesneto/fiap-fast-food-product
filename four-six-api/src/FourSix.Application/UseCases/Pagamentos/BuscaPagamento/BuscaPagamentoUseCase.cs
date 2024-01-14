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
    
        public class BuscaPagamentoUseCase : IBuscaPagamentoUseCase
    {
            private readonly IPagamentoRepository _pagamentoRepository;
            private readonly IUnitOfWork _unitOfWork;
            private IOutputPort<Pagamento> _outputPort;

            public BuscaPagamentoUseCase(
                IPagamentoRepository pagamentoRepository,
                IUnitOfWork unitOfWork)
            {
                _outputPort = new BuscaPagamentoPresenter();
                _pagamentoRepository = pagamentoRepository;
                _unitOfWork = unitOfWork;
            }

            /// <inheritdoc />
            public void SetOutputPort(IOutputPort<Pagamento> outputPort) => _outputPort = outputPort;

            /// <inheritdoc />
            public Task Execute(Guid pedidoId) =>
                BuscaPagamento(pedidoId);

            private async Task BuscaPagamento(Guid pagamentoId)
            {
                var pagamento = _pagamentoRepository.Obter(pagamentoId);
                _outputPort?.Ok(pagamento);
            }
        }
    

}
