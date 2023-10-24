namespace FourSix.Domain.Entities.PedidoAggregate
{
    public class PedidoStatus
    {
        public PedidoStatus()
        {
        }

        public PedidoStatus(Guid pedidoId, EnumStatus statusId, DateTime dataStatus)
        {
            PedidoId = pedidoId;
            StatusId = statusId;
            DataStatus = dataStatus;
        }

        public Guid PedidoId { get; }
        public EnumStatus StatusId { get; }
        public DateTime DataStatus { get; }

        public Status Status { get; set; }
    }
}
