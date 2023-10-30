using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.Domain.Entities.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Infrastructure.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<StatusPedido>()
                .HasData(
                new
                {
                    Id = EnumStatusPedido.Recebido,
                    Descricao = "Recebido"
                },
                new
                {
                    Id = EnumStatusPedido.Pago,
                    Descricao = "Pago"
                },
                new
                {
                    Id = EnumStatusPedido.EmPreparacao,
                    Descricao = "Em Preparação"
                },
                new
                {
                    Id = EnumStatusPedido.Montagem,
                    Descricao = "Montagem"
                },
                new
                {
                    Id = EnumStatusPedido.Pronto,
                    Descricao = "Pronto"
                },
                new
                {
                    Id = EnumStatusPedido.Finalizado,
                    Descricao = "Finalizado"
                });

            builder.Entity<StatusPagamento>()
                .HasData(
                 new
                 {
                     Id = EnumStatusPagamento.AguardandoPagamento,
                     Descricao = "Aguardando Pagamento"
                 },
                new
                {
                    Id = EnumStatusPagamento.Pago,
                    Descricao = "Pago"
                },
                new
                {
                    Id = EnumStatusPagamento.Cancelado,
                    Descricao = "Cancelado"
                });

            builder.Entity<Produto>()
               .HasData(
                new {
                    Id = Guid.NewGuid(),
                    Nome = "Burger Four",
                    Descricao = "Pão, carne, alface, tomate e maionese ESPECIAL",
                    Categoria = EnumCategoriaProduto.Lanche,
                    Preco = 5.5m,
                    Ativo = true
                },
                new {
                    Id = Guid.NewGuid(),
                    Nome = "Burguer Six",
                    Descricao = "Pão, carne, queijo, alface, tomate e maionese ESPECIAL",
                    Categoria = EnumCategoriaProduto.Lanche,
                    Preco = 7.5m,
                    Ativo = true
                },
                new {
                    Id = Guid.NewGuid(),
                    Nome = "Burguer FourSix",
                    Descricao = "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL",
                    Categoria = EnumCategoriaProduto.Lanche,
                    Preco = 10m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "Coca-cola",
                    Descricao = "Coca-cola 600ml",
                    Categoria = EnumCategoriaProduto.Bebida,
                    Preco = 8.25m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "H2O",
                    Descricao = "H2O 500ml",
                    Categoria = EnumCategoriaProduto.Bebida,
                    Preco = 8.25m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "Suco Natural de Laranja",
                    Descricao = "Suco Natural de Laranja 500ml",
                    Categoria = EnumCategoriaProduto.Bebida,
                    Preco = 10m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "Batata Frita",
                    Descricao = "Batata Frita especial",
                    Categoria = EnumCategoriaProduto.Acompanhamento,
                    Preco = 6.50m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "Onion",
                    Descricao = "Cebola empanada especial",
                    Categoria = EnumCategoriaProduto.Acompanhamento,
                    Preco = 8.25m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "Sorvete de Baunilha",
                    Descricao = "Casquinha de sorvete de baunilha",
                    Categoria = EnumCategoriaProduto.Sobremesa,
                    Preco = 1.25m,
                    Ativo = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Nome = "Bolo Sensação",
                    Descricao = "Bolo de chocolate com recheio de creme de morango",
                    Categoria = EnumCategoriaProduto.Sobremesa,
                    Preco = 3.25m,
                    Ativo = true
                });
        }
    }
}
