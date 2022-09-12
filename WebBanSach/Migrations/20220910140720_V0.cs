using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanSach.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhaXuatBan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNXB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNXB = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MaTacGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenTheLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaTL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tenSach = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donGia = table.Column<int>(type: "int", nullable: false),
                    idNXB = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SACH_NXB",
                        column: x => x.idNXB,
                        principalTable: "NhaXuatBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BP_SachTacGia",
                columns: table => new
                {
                    IdSach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTacGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BP_SachTacGia", x => new { x.IdSach, x.IdTacGia });
                    table.ForeignKey(
                        name: "FK_SACH_TG1",
                        column: x => x.IdSach,
                        principalTable: "Sach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SACH_TG2",
                        column: x => x.IdTacGia,
                        principalTable: "TacGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BP_SachTheLoai",
                columns: table => new
                {
                    IdSach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTheLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BP_SachTheLoai", x => new { x.IdSach, x.IdTheLoai });
                    table.ForeignKey(
                        name: "FK_Sach_TL",
                        column: x => x.IdSach,
                        principalTable: "Sach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheLoai_Sach",
                        column: x => x.IdTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BP_SachTacGia_IdTacGia",
                table: "BP_SachTacGia",
                column: "IdTacGia");

            migrationBuilder.CreateIndex(
                name: "IX_BP_SachTheLoai_IdTheLoai",
                table: "BP_SachTheLoai",
                column: "IdTheLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_idNXB",
                table: "Sach",
                column: "idNXB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BP_SachTacGia");

            migrationBuilder.DropTable(
                name: "BP_SachTheLoai");

            migrationBuilder.DropTable(
                name: "TacGia");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "TheLoai");

            migrationBuilder.DropTable(
                name: "NhaXuatBan");
        }
    }
}
