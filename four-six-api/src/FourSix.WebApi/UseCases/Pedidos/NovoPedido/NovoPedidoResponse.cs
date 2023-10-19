using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pedidos.NovoPedido
{
    public class NovoPedidoResponse
    {
        public NovoPedidoResponse(PedidoModel pedidoModel) => this.Pedido = pedidoModel;
        public PedidoModel Pedido { get; }
    }
}
