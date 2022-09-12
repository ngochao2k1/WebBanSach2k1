using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanSach.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTientrcVAT = table.Column<int>(type: "int", nullable: false),
                    VAT = table.Column<float>(type: "real", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    IdSach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDonHang = table.Column<int>(type: "int", nullable: false),
                    SoLuongMua = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => new { x.IdSach, x.IdDonHang });
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang1",
                        column: x => x.IdSach,
                        principalTable: "Sach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang2",
                        column: x => x.IdDonHang,
                        principalTable: "DonHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_IdDonHang",
                table: "ChiTietDonHang",
                column: "IdDonHang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}
