﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NerdStore.Vendas.Data.Migrations
{
    public partial class InitialVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Percentual = table.Column<decimal>(type: "numeric", nullable: true),
                    ValorDesconto = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    TipoDescontoVoucher = table.Column<int>(type: "integer", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataUtilizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataValidade = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Utilizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uuid", nullable: true),
                    VoucherUtilizado = table.Column<bool>(type: "boolean", nullable: false),
                    Desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PedidoStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoNome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItems_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "PedidoItems",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VoucherId",
                table: "Pedidos",
                column: "VoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItems");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
