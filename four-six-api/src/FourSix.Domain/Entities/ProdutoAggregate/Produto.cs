namespace FourSix.Domain.Entities.ProdutoAggregate
{
    public enum EnumCategoriaProduto
    {
        Lanche = 1,
        Acompanhamento = 2,
        Sobremesa = 3,
        Bebida = 4
    }

    public class Produto : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Produto() { }
        public Produto(Guid id, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco, bool ativo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
            Ativo = ativo;
        }

        public string Nome { get; }
        public string Descricao { get; }
        public EnumCategoriaProduto Categoria { get; }
        public decimal Preco { get; }
        public bool Ativo { get; private set; }

        public void InativarProduto()
        {
            Ativo = false;
        }
    }
}
