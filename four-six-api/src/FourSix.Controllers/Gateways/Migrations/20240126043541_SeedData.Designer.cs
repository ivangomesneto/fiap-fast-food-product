﻿// <auto-generated />
using System;
using FourSix.Controllers.Gateways.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FourSix.Controllers.Gateways.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240126043541_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FourSix.Domain.Entities.ClienteAggregate.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("717b2fb9-4bbe-4a8c-8574-7808cd652e0b"),
                            Cpf = "12851671049",
                            Email = "joao.silva@gmail.com",
                            Nome = "João da Silva Gomes"
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PagamentoAggregate.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoQR")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Desconto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("StatusId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("ValorPago")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPedido")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("StatusId");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PagamentoAggregate.StatusPagamento", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("StatusPagamento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Descricao = "Aguardando Pagamento"
                        },
                        new
                        {
                            Id = (short)2,
                            Descricao = "Pago"
                        },
                        new
                        {
                            Id = (short)3,
                            Descricao = "Cancelado"
                        },
                        new
                        {
                            Id = (short)4,
                            Descricao = "Negado"
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroPedido"));

                    b.Property<short>("StatusId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("StatusId");

                    b.ToTable("Pedido", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("78e3b8d0-be9a-4407-9304-c61788797808"),
                            ClienteId = new Guid("717b2fb9-4bbe-4a8c-8574-7808cd652e0b"),
                            DataPedido = new DateTime(2024, 1, 25, 20, 35, 41, 687, DateTimeKind.Local).AddTicks(3854),
                            NumeroPedido = 1,
                            StatusId = (short)1
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.PedidoCheckout", b =>
                {
                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sequencia")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataStatus")
                        .HasColumnType("datetime2");

                    b.Property<short>("StatusId")
                        .HasColumnType("smallint");

                    b.HasKey("PedidoId", "Sequencia");

                    b.HasIndex("StatusId");

                    b.ToTable("PedidoCheckout", (string)null);

                    b.HasData(
                        new
                        {
                            PedidoId = new Guid("78e3b8d0-be9a-4407-9304-c61788797808"),
                            Sequencia = 0,
                            DataStatus = new DateTime(2024, 1, 25, 20, 35, 41, 687, DateTimeKind.Local).AddTicks(3854),
                            StatusId = (short)1
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.PedidoItem", b =>
                {
                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemPedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("PedidoId", "ItemPedidoId");

                    b.HasIndex("ItemPedidoId");

                    b.ToTable("PedidoItem", (string)null);

                    b.HasData(
                        new
                        {
                            PedidoId = new Guid("78e3b8d0-be9a-4407-9304-c61788797808"),
                            ItemPedidoId = new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"),
                            Observacao = "Sem tomate",
                            Quantidade = 2,
                            ValorUnitario = 5.5m
                        },
                        new
                        {
                            PedidoId = new Guid("78e3b8d0-be9a-4407-9304-c61788797808"),
                            ItemPedidoId = new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"),
                            Quantidade = 1,
                            ValorUnitario = 8.25m
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.StatusPedido", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("StatusPedido", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Descricao = "Recebido"
                        },
                        new
                        {
                            Id = (short)2,
                            Descricao = "Pago"
                        },
                        new
                        {
                            Id = (short)3,
                            Descricao = "Em Preparação"
                        },
                        new
                        {
                            Id = (short)4,
                            Descricao = "Montagem"
                        },
                        new
                        {
                            Id = (short)5,
                            Descricao = "Pronto"
                        },
                        new
                        {
                            Id = (short)6,
                            Descricao = "Finalizado"
                        },
                        new
                        {
                            Id = (short)7,
                            Descricao = "Cancelado"
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"),
                            Ativo = true,
                            Categoria = 1,
                            Descricao = "Pão, carne, alface, tomate e maionese ESPECIAL",
                            Nome = "Burger Four",
                            Preco = 5.5m
                        },
                        new
                        {
                            Id = new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"),
                            Ativo = true,
                            Categoria = 1,
                            Descricao = "Pão, carne, queijo, alface, tomate e maionese ESPECIAL",
                            Nome = "Burguer Six",
                            Preco = 7.5m
                        },
                        new
                        {
                            Id = new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"),
                            Ativo = true,
                            Categoria = 1,
                            Descricao = "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL",
                            Nome = "Burguer FourSix",
                            Preco = 10m
                        },
                        new
                        {
                            Id = new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"),
                            Ativo = true,
                            Categoria = 4,
                            Descricao = "Coca-cola 600ml",
                            Nome = "Coca-cola",
                            Preco = 8.25m
                        },
                        new
                        {
                            Id = new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"),
                            Ativo = true,
                            Categoria = 4,
                            Descricao = "H2O 500ml",
                            Nome = "H2O",
                            Preco = 8.25m
                        },
                        new
                        {
                            Id = new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"),
                            Ativo = true,
                            Categoria = 4,
                            Descricao = "Suco Natural de Laranja 500ml",
                            Nome = "Suco Natural de Laranja",
                            Preco = 10m
                        },
                        new
                        {
                            Id = new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"),
                            Ativo = true,
                            Categoria = 2,
                            Descricao = "Batata Frita especial",
                            Nome = "Batata Frita",
                            Preco = 6.50m
                        },
                        new
                        {
                            Id = new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"),
                            Ativo = true,
                            Categoria = 2,
                            Descricao = "Cebola empanada especial",
                            Nome = "Onion",
                            Preco = 8.25m
                        },
                        new
                        {
                            Id = new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"),
                            Ativo = true,
                            Categoria = 3,
                            Descricao = "Casquinha de sorvete de baunilha",
                            Nome = "Sorvete de Baunilha",
                            Preco = 1.25m
                        },
                        new
                        {
                            Id = new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"),
                            Ativo = true,
                            Categoria = 3,
                            Descricao = "Bolo de chocolate com recheio de creme de morango",
                            Nome = "Bolo Sensação",
                            Preco = 3.25m
                        });
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PagamentoAggregate.Pagamento", b =>
                {
                    b.HasOne("FourSix.Domain.Entities.PedidoAggregate.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourSix.Domain.Entities.PagamentoAggregate.StatusPagamento", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.Pedido", b =>
                {
                    b.HasOne("FourSix.Domain.Entities.ClienteAggregate.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourSix.Domain.Entities.PedidoAggregate.StatusPedido", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.PedidoCheckout", b =>
                {
                    b.HasOne("FourSix.Domain.Entities.PedidoAggregate.Pedido", null)
                        .WithMany("HistoricoCheckout")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourSix.Domain.Entities.PedidoAggregate.StatusPedido", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.PedidoItem", b =>
                {
                    b.HasOne("FourSix.Domain.Entities.ProdutoAggregate.Produto", "ItemPedido")
                        .WithMany()
                        .HasForeignKey("ItemPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourSix.Domain.Entities.PedidoAggregate.Pedido", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemPedido");
                });

            modelBuilder.Entity("FourSix.Domain.Entities.PedidoAggregate.Pedido", b =>
                {
                    b.Navigation("HistoricoCheckout");

                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
