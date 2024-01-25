using FourSix.WebApi.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutosPorCategoria
{
    public class ObtemProdutosPorCategoriaResponse
    {
        public ObtemProdutosPorCategoriaResponse(IList<ProdutoModel> produtosModel) => this.Produtos = produtosModel;
        public IList<ProdutoModel> Produtos { get; }
    }
}
