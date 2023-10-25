using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Produtos.AlteraProduto
{
    public class AlteraProdutoResponse
    {
        public AlteraProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
