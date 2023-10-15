namespace FourSix.Domain.Entities
{
    public interface ISetRepository<T> where T : class
    {
        Task Incluir(T entidade);
        Task Alterar(T entidade);
        Task Excluir(Guid id);
        Task<int> Salvar();
    }
}
