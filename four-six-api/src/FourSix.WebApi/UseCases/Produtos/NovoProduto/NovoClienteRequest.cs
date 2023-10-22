using FourSix.Domain.Entities.ProdutoAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoRequest
    {
        [SwaggerSchema(Nullable = false)]
        public Produto produto { get; set; }

    }
}
