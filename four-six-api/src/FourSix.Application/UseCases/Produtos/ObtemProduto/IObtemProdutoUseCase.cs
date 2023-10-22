namespace FourSix.Application.UseCases.Produtos.ObtemProduto
{
    public interface IObtemProdutoUseCase
    {
        Task Execute(string id);
        void SetOutputPort(IOutputPort outputPort);
    }
}
