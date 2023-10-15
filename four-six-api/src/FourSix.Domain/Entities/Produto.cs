namespace FourSix.Domain.Entities
{
    public enum EnumCategoriaProduto
    {
        Lanche,
        Acompanhamento,
        Sobremesa
    }

    public class Produto : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Produto(Guid id, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
        }

        public string Nome { get; }
        public string Descricao { get; } 
        public EnumCategoriaProduto Categoria { get; }
        public decimal Preco { get; }
    }
}
