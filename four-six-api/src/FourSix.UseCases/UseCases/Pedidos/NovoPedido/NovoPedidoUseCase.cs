using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pedidos.NovoPedido
{
    public class NovoPedidoUseCase : INovoPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoCheckoutRepository _pedidoCheckoutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NovoPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork,
            IPedidoItemRepository pedidoItemRepository,
            IPedidoCheckoutRepository pedidoCheckoutRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
            _pedidoItemRepository = pedidoItemRepository;
            _pedidoCheckoutRepository = pedidoCheckoutRepository;
        }

        public async Task Execute(DateTime dataPedido, Guid? clienteId, ICollection<Tuple<Guid, decimal, int, string>> itens)
        {
            var id = Guid.NewGuid();

            await this.IncluiPedido(
                new Pedido(id,
                dataPedido,
                clienteId,
                itens.Select(i => new PedidoItem(id, i.Item1, i.Item2, i.Item3, i.Item4)).ToList(),
                new List<PedidoCheckout> { new PedidoCheckout(id, 1, EnumStatusPedido.Recebido, DateTime.Now) }));
        }

        private async Task IncluiPedido(Pedido pedido)
        {
            if (this._pedidoRepository
                .Listar(q => q.NumeroPedido == pedido.NumeroPedido).Any())
            {
                throw new Exception("Pedido já existe");
            }

            await this._pedidoRepository
                 .Incluir(pedido)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
