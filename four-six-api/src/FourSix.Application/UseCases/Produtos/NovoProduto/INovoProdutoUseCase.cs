using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.NovoProduto
{
    public interface IAlteraProdutoUseCase
    {
        
        Task Execute(Produto produto);

        void SetOutputPort(IOutputPort outputPort);
    }
}
