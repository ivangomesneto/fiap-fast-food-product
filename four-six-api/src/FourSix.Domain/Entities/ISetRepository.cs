namespace FourSix.Domain.Entities
{
    public interface ISetRepository<T> where T : class
    {
        int Incluir(T produto);
        int Alterar(T produto);
        int Excluir(Guid id);
    }
}
