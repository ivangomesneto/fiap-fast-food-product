namespace FourSix.Domain.Entities.PedidoAggregate
{
    public interface IPedidoStatusRepository : IGetRepository<PedidoStatus, EnumStatus>, ISetRepository<PedidoStatus, EnumStatus>
    {
    }
}
