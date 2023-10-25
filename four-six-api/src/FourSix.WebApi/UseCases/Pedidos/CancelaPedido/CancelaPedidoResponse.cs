using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pedidos.CancelaPedido
{
    public class CancelaPedidoResponse
    {
        public CancelaPedidoResponse(PedidoModel pedidoModel) => Pedido = pedidoModel;
        public PedidoModel Pedido { get; }
    }
}
