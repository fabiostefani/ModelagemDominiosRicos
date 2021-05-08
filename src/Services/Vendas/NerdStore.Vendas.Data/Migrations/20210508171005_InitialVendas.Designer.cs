﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NerdStore.Vendas.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NerdStore.Vendas.Data.Migrations
{
    [DbContext(typeof(VendasContext))]
    [Migration("20210508171005_InitialVendas")]
    partial class InitialVendas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NerdStore.Vendas.Domain.Pedidos.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("numeric");

                    b.Property<int>("PedidoStatus")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("VoucherId")
                        .HasColumnType("uuid");

                    b.Property<bool>("VoucherUtilizado")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("NerdStore.Vendas.Domain.Pedidos.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItems");
                });

            modelBuilder.Entity("NerdStore.Vendas.Domain.Vouchers.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataUtilizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("Percentual")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("TipoDescontoVoucher")
                        .HasColumnType("integer");

                    b.Property<bool>("Utilizado")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("ValorDesconto")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("NerdStore.Vendas.Domain.Pedidos.Pedido", b =>
                {
                    b.HasOne("NerdStore.Vendas.Domain.Vouchers.Voucher", "Voucher")
                        .WithMany("Pedidos")
                        .HasForeignKey("VoucherId");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("NerdStore.Vendas.Domain.Pedidos.PedidoItem", b =>
                {
                    b.HasOne("NerdStore.Vendas.Domain.Pedidos.Pedido", "Pedido")
                        .WithMany("PedidoItems")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("NerdStore.Vendas.Domain.Pedidos.Pedido", b =>
                {
                    b.Navigation("PedidoItems");
                });

            modelBuilder.Entity("NerdStore.Vendas.Domain.Vouchers.Voucher", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
