using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoResponse
    {
        public NovoProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
