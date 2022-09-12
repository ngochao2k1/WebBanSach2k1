using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanSach.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TongTientrcVAT",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "DonHang");

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhach",
                table: "DonHang",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    IDHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongTientrcVAT = table.Column<int>(type: "int", nullable: false),
                    VAT = table.Column<float>(type: "real", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    IdDonHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.IDHoaDon);
                    table.ForeignKey(
                        name: "FK_hoaDons_DonHang_IdDonHang",
                        column: x => x.IdDonHang,
                        principalTable: "DonHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_IdDonHang",
                table: "hoaDons",
                column: "IdDonHang",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropColumn(
                name: "IdKhach",
                table: "DonHang");

            migrationBuilder.AddColumn<float>(
                name: "TongTien",
                table: "DonHang",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TongTientrcVAT",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "VAT",
                table: "DonHang",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
