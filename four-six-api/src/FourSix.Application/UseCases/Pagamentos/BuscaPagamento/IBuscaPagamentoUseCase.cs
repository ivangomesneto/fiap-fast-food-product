using FourSix.Domain.Entities.PagamentoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSix.Application.UseCases.Pagamentos.BuscaPagamento
{
    public interface IBuscaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(Guid pagamentoId);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort<Pagamento> outputPort);
    }
}
