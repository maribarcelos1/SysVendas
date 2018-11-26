﻿// <auto-generated />
using ERP;
using ERP.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ERP.Migrations
{
    [DbContext(typeof(SysVendasContexto))]
    [Migration("20180303192014_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ERP.Carrinhos.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NumeroItem");

                    b.Property<int>("ProdutoId");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(10, 3)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("UsuarioId");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Carrinhos");
                });

            modelBuilder.Entity("ERP.Clientes.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Endereco");

                    b.Property<string>("Identidade");

                    b.Property<bool>("Inadimplente");

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Observacao");

                    b.Property<decimal>("SaldoDebitos")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<bool>("Status");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ERP.ItensVendas.ItensVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CodigoVenda");

                    b.Property<int>("NumeroItem");

                    b.Property<decimal>("PrecoProduto")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProdutoId");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(10, 3)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("VendaId");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItensVendas");
                });

            modelBuilder.Entity("ERP.Produtos.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoProduto");

                    b.Property<decimal>("Estoque")
                        .HasColumnType("decimal(10, 3)");

                    b.Property<string>("NomeProduto");

                    b.Property<decimal>("PrecoPago")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ERP.SysVendas.SysVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ativa");

                    b.Property<Guid>("Chave");

                    b.Property<DateTime>("DataAtivacao");

                    b.Property<DateTime>("DataExpira");

                    b.Property<int>("Dias");

                    b.Property<int>("Utilizada");

                    b.HasKey("Id");

                    b.ToTable("Sysvendas");
                });

            modelBuilder.Entity("ERP.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Endereco");

                    b.Property<string>("Login");

                    b.Property<string>("Senha");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ERP.Vendas.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<Guid>("CodigoVenda");

                    b.Property<DateTime>("DataPagamento");

                    b.Property<DateTime>("DataVencimento");

                    b.Property<DateTime>("DataVenda");

                    b.Property<decimal>("Desconto");

                    b.Property<decimal>("PagamentoCartaoCredito");

                    b.Property<decimal>("PagamentoCartaoDebito");

                    b.Property<decimal>("PagamentoCheque");

                    b.Property<decimal>("PagamentoDinheiro");

                    b.Property<int>("PagamentoRealizado");

                    b.Property<int>("TipoVenda");

                    b.Property<decimal>("TotalPago")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("TotalVenda")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("Troco");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("ERP.Carrinhos.Carrinho", b =>
                {
                    b.HasOne("ERP.Produtos.Produto", "Produto")
                        .WithMany("Carrinho")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERP.Usuarios.Usuario", "Usuario")
                        .WithMany("Carrinho")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERP.Clientes.Cliente", b =>
                {
                    b.HasOne("ERP.Usuarios.Usuario", "Usuario")
                        .WithMany("Clientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("ERP.ObjetosValor.CPF", "Cpf", b1 =>
                        {
                            b1.Property<int>("ClienteId");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("NumeroCpf")
                                .HasColumnType("varchar(15)");

                            b1.ToTable("Clientes");

                            b1.HasOne("ERP.Clientes.Cliente")
                                .WithOne("Cpf")
                                .HasForeignKey("ERP.ObjetosValor.CPF", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("ERP.ObjetosValor.NomeCompleto", "NomeCompleto", b1 =>
                        {
                            b1.Property<int>("ClienteId");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnName("Nome")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasColumnName("SobreNome")
                                .HasColumnType("varchar(50)");

                            b1.ToTable("Clientes");

                            b1.HasOne("ERP.Clientes.Cliente")
                                .WithOne("NomeCompleto")
                                .HasForeignKey("ERP.ObjetosValor.NomeCompleto", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("ERP.ObjetosValor.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<int>("ClienteId");

                            b1.Property<string>("Ddd")
                                .IsRequired()
                                .HasColumnName("Ddd")
                                .HasColumnType("varchar(3)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("NumeroTelefone")
                                .HasColumnType("varchar(15)");

                            b1.ToTable("Clientes");

                            b1.HasOne("ERP.Clientes.Cliente")
                                .WithOne("Telefone")
                                .HasForeignKey("ERP.ObjetosValor.Telefone", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ERP.ItensVendas.ItensVenda", b =>
                {
                    b.HasOne("ERP.Produtos.Produto", "Produto")
                        .WithMany("ItensVendas")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERP.Vendas.Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERP.Usuarios.Usuario", b =>
                {
                    b.OwnsOne("ERP.ObjetosValor.NomeCompleto", "NomeCompleto", b1 =>
                        {
                            b1.Property<int?>("UsuarioId");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnName("Nome")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasColumnName("SobreNome")
                                .HasColumnType("varchar(50)");

                            b1.ToTable("Usuarios");

                            b1.HasOne("ERP.Usuarios.Usuario")
                                .WithOne("NomeCompleto")
                                .HasForeignKey("ERP.ObjetosValor.NomeCompleto", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("ERP.ObjetosValor.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<int?>("UsuarioId");

                            b1.Property<string>("Ddd")
                                .IsRequired()
                                .HasColumnName("Ddd")
                                .HasColumnType("varchar(3)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Numero")
                                .HasColumnType("varchar(15)");

                            b1.ToTable("Usuarios");

                            b1.HasOne("ERP.Usuarios.Usuario")
                                .WithOne("Telefone")
                                .HasForeignKey("ERP.ObjetosValor.Telefone", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ERP.Vendas.Venda", b =>
                {
                    b.HasOne("ERP.Clientes.Cliente", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERP.Usuarios.Usuario", "Usuario")
                        .WithMany("Vendas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
