using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Pedidos.AlteraStatusPedido
{
    public class AlteraStatusPedidoResponse
    {
        public AlteraStatusPedidoResponse(PedidoModel pedidoModel) => Pedido = pedidoModel;
        public PedidoModel Pedido { get; }
    }
}
