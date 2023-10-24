using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.AlteraStatusPedido
{
    public class AlteraStatusPedidoUseCase : IAlteraStatusPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pedido> _outputPort;

        public AlteraStatusPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork,
            IPedidoStatusRepository pedidoStatusRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new AlteraStatusPedidoPresenter();
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pedido> outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public async Task Execute(Guid pedidoId, EnumStatus statusId, DateTime dataStatus)
        {
            await this.AlterarStatusPedido(pedidoId, statusId, dataStatus);
        }

        private async Task AlterarStatusPedido(Guid pedidoId, EnumStatus statusId, DateTime dataStatus)
        {
            var pedido = this._pedidoRepository.Listar(q => q.Id == pedidoId).FirstOrDefault();

            if (pedido == null)
            {
                this._outputPort.NotFound();
                return;
            }

            var novaSequencia = _pedidoStatusRepository.Listar(l => l.PedidoId == pedidoId).Max(l => l.Sequencia) + 1;

            await this._pedidoStatusRepository
                 .Incluir(new PedidoStatus(pedidoId, novaSequencia, statusId, dataStatus))
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(pedido);
        }
    }
}
