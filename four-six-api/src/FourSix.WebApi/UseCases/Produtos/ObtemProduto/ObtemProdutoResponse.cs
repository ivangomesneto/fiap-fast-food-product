using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProduto
{
    public class ObtemProdutoResponse
    {
        public ObtemProdutoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
