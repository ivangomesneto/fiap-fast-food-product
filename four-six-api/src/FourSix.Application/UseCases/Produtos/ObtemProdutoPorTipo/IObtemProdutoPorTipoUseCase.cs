namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorTipo
{
    public interface IObtemProdutoPorTipoUseCase
    {
        Task Execute();
        void SetOutputPort(IOutputPort outputPort);
    }
}
