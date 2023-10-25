using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProdutoPorTipo
{
    public class ObtemProdutoPorTipoResponse
    {
        public ObtemProdutoPorTipoResponse(ProdutoModel produtoModel) => this.Produto = produtoModel;
        public ProdutoModel Produto { get; }
    }
}
