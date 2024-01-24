using FourSix.Domain.Entities.PagamentoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSix.Application.UseCases.Pagamentos.BuscaPagamento
{
        public sealed class BuscaPagamentoPresenter : IOutputPort<Pagamento>
        {
            public Pagamento Pagamento { get; private set; }
            public bool InvalidOutput { get; private set; }
            public bool NotFoundOutput { get; private set; }
            public bool ExistOutput { get; private set; }
            public void Invalid() => InvalidOutput = true;
            public void NotFound() => NotFoundOutput = true;
            public void Exist() => ExistOutput = true;
            public void Ok(Pagamento pagamento) => Pagamento = pagamento;
        }
}
