namespace FourSix.Domain.Entities.PedidoAggregate
{
    public enum EnumStatus
    {
        Aberto = 1,
        Pago = 2,
        EmPreparacao = 3,
        Montagem = 4,
        Pronto = 5,
        Enregue = 6,
        Cancelado = 7
    }

    public class Status
    {
        public EnumStatus Id { get; }
        public string Descricao { get; }
    }
}
