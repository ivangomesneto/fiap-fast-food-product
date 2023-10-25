using FourSix.Application.Services;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.NovoPedido
{
    public class NovoPedidoUseCase : INovoPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pedido> _outputPort;

        public NovoPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork)
        {
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new NovoPedidoPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pedido> outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(string numeroPedido, DateTime dataPedido, Guid? clienteId) =>
            this.IncluiPedido(
                new Pedido(Guid.NewGuid(),
                numeroPedido,
                dataPedido,
                clienteId));

        private async Task IncluiPedido(Pedido pedido)
        {
            if (this._pedidoRepository
                .Listar(q => q.NumeroPedido == pedido.NumeroPedido).Any())
            {
                this._outputPort.Exist();
                return;
            }

            await this._pedidoRepository
                 .Incluir(pedido)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(pedido);
        }
    }
}
