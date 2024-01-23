using FourSix.WebApi.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutoPorCategoria
{
    public class ObtemProdutoPorCategoriaResponse
    {
        public ObtemProdutoPorCategoriaResponse(IList<ProdutoModel> produtosModel) => this.Produtos = produtosModel;
        public IList<ProdutoModel> Produtos { get; }
    }
}
