﻿// <auto-generated />
using System;
using DevIo.NerdStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevIo.NerdStore.Data.Migrations
{
    [DbContext(typeof(CatalogoContext))]
    [Migration("20200704190156_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevIo.NerdStore.Catalogo.Domain.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f28c3329-75ab-4b73-b5e4-585bbc927259"),
                            Codigo = 102,
                            Nome = "Adesivos"
                        },
                        new
                        {
                            Id = new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"),
                            Codigo = 100,
                            Nome = "Camisetas"
                        },
                        new
                        {
                            Id = new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"),
                            Codigo = 101,
                            Nome = "Canecas"
                        });
                });

            modelBuilder.Entity("DevIo.NerdStore.Catalogo.Domain.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c21bbe90-1553-4096-86cb-37eddb612449"),
                            Ativo = true,
                            CategoriaId = new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 542, DateTimeKind.Local).AddTicks(8100),
                            Descricao = "Camiseta 100% algodão",
                            Imagem = "camiseta2.jpg",
                            Nome = "Camiseta Code life preta",
                            QuantidadeEstoque = 0,
                            Valor = 90m
                        },
                        new
                        {
                            Id = new Guid("cdff447b-749a-46f0-be02-71853fbadd64"),
                            Ativo = true,
                            CategoriaId = new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5410),
                            Descricao = "Caneca de porcelana",
                            Imagem = "caneca4.jpg",
                            Nome = "Caneca no coffe no code",
                            QuantidadeEstoque = 0,
                            Valor = 10m
                        },
                        new
                        {
                            Id = new Guid("64d3bd9c-f59e-4d30-9ce4-37b3f1f8be79"),
                            Ativo = true,
                            CategoriaId = new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5650),
                            Descricao = "Camiseta 100% algodão",
                            Imagem = "camiseta4.jpg",
                            Nome = "Camiseta Debug",
                            QuantidadeEstoque = 0,
                            Valor = 110m
                        },
                        new
                        {
                            Id = new Guid("6f01cdaf-efcd-43ad-af23-13075155c2dd"),
                            Ativo = true,
                            CategoriaId = new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5670),
                            Descricao = "Camiseta 100% algodão",
                            Imagem = "camiseta3.jpg",
                            Nome = "Camiseta Code life branca",
                            QuantidadeEstoque = 0,
                            Valor = 80m
                        },
                        new
                        {
                            Id = new Guid("dc1d7b5e-f54e-481b-a20a-332e7f7f3c70"),
                            Ativo = true,
                            CategoriaId = new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5680),
                            Descricao = "Caneca de porcelana",
                            Imagem = "caneca1.jpg",
                            Nome = "Caneca Star bucks",
                            QuantidadeEstoque = 0,
                            Valor = 20m
                        },
                        new
                        {
                            Id = new Guid("d58bff42-99ae-4a0b-9790-c4f5f8ce24fe"),
                            Ativo = true,
                            CategoriaId = new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5690),
                            Descricao = "Caneca de porcelana",
                            Imagem = "caneca2.jpg",
                            Nome = "Caneca Prgramador",
                            QuantidadeEstoque = 0,
                            Valor = 20m
                        },
                        new
                        {
                            Id = new Guid("f4cd1c0b-06aa-487a-bd2b-bfbfdcbd903a"),
                            Ativo = true,
                            CategoriaId = new Guid("72ec0ee4-5793-45c7-b7c1-b61e3b73c253"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5700),
                            Descricao = "Camiseta 100% algodão",
                            Imagem = "camiseta1.jpg",
                            Nome = "Camiseta Software",
                            QuantidadeEstoque = 0,
                            Valor = 80m
                        },
                        new
                        {
                            Id = new Guid("a781fc58-1b2e-42a5-b4fa-84f0df30a9eb"),
                            Ativo = true,
                            CategoriaId = new Guid("2b047322-0b10-4faa-b5de-8cdba0840606"),
                            DataCadastro = new DateTime(2020, 7, 4, 16, 1, 56, 556, DateTimeKind.Local).AddTicks(5720),
                            Descricao = "Caneca de porcelana",
                            Imagem = "caneca3.jpg",
                            Nome = "Caneca Turn code",
                            QuantidadeEstoque = 0,
                            Valor = 20m
                        });
                });

            modelBuilder.Entity("DevIo.NerdStore.Catalogo.Domain.Produto", b =>
                {
                    b.HasOne("DevIo.NerdStore.Catalogo.Domain.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("DevIo.NerdStore.Catalogo.Domain.Dimensoes", "Dimensoes", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Altura")
                                .HasColumnName("Altura")
                                .HasColumnType("int");

                            b1.Property<int>("Largura")
                                .HasColumnName("Largura")
                                .HasColumnType("int");

                            b1.Property<int>("Profundidade")
                                .HasColumnName("Profundidade")
                                .HasColumnType("int");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");

                            b1.HasData(
                                new
                                {
                                    ProdutoId = new Guid("c21bbe90-1553-4096-86cb-37eddb612449"),
                                    Altura = 5,
                                    Largura = 5,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("cdff447b-749a-46f0-be02-71853fbadd64"),
                                    Altura = 12,
                                    Largura = 8,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("64d3bd9c-f59e-4d30-9ce4-37b3f1f8be79"),
                                    Altura = 5,
                                    Largura = 5,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("6f01cdaf-efcd-43ad-af23-13075155c2dd"),
                                    Altura = 5,
                                    Largura = 5,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("dc1d7b5e-f54e-481b-a20a-332e7f7f3c70"),
                                    Altura = 12,
                                    Largura = 8,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("d58bff42-99ae-4a0b-9790-c4f5f8ce24fe"),
                                    Altura = 12,
                                    Largura = 8,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("f4cd1c0b-06aa-487a-bd2b-bfbfdcbd903a"),
                                    Altura = 5,
                                    Largura = 5,
                                    Profundidade = 5
                                },
                                new
                                {
                                    ProdutoId = new Guid("a781fc58-1b2e-42a5-b4fa-84f0df30a9eb"),
                                    Altura = 12,
                                    Largura = 8,
                                    Profundidade = 5
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}