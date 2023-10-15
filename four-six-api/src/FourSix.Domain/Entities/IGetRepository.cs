namespace FourSix.Domain.Entities
{
    public interface IGetRepository<T> where T : class
    {
        Task<IQueryable<T>> Listar();
        Task<T> Obter(Guid id);
    }
}
