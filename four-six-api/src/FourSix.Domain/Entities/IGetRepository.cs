namespace FourSix.Domain.Entities
{
    public interface IGetRepository<T> where T : class
    {
        IQueryable<T> Listar();
        T Obter(Guid id);
    }
}
