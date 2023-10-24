namespace FourSix.Domain.Entities.PedidoAggregate
{
    public class PedidoStatus
    {
        public PedidoStatus()
        {
        }

        public PedidoStatus(Guid pedidoId, int sequencia, EnumStatus statusId, DateTime dataStatus)
        {
            PedidoId = pedidoId;
            Sequencia = sequencia;
            StatusId = statusId;
            DataStatus = dataStatus;
        }

        public Guid PedidoId { get; }
        public int Sequencia { get; }
        public EnumStatus StatusId { get; }
        public DateTime DataStatus { get; }

        public Status Status { get; set; }
    }
}
