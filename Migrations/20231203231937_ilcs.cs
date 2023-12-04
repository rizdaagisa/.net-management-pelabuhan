using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ILCS_restfulAPI.Migrations
{
    /// <inheritdoc />
    public partial class ilcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_negara",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kd_negara = table.Column<string>(type: "text", nullable: false),
                    nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_negara", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_tarif",
                columns: table => new
                {
                    kd_tarif = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tarif_bm = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_tarif", x => x.kd_tarif);
                });

            migrationBuilder.CreateTable(
                name: "m_pelabuhan",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_negara = table.Column<int>(type: "integer", nullable: false),
                    nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_pelabuhan", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_pelabuhan_m_negara_id_negara",
                        column: x => x.id_negara,
                        principalTable: "m_negara",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "m_barang",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kd_tarif = table.Column<long>(type: "bigint", nullable: false),
                    nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_barang", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_barang_m_tarif_kd_tarif",
                        column: x => x.kd_tarif,
                        principalTable: "m_tarif",
                        principalColumn: "kd_tarif",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_pelabuhan = table.Column<int>(type: "integer", nullable: false),
                    id_barang = table.Column<int>(type: "integer", nullable: false),
                    kd_tarif = table.Column<long>(type: "bigint", nullable: false),
                    harga = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_transactions_m_barang_id_barang",
                        column: x => x.id_barang,
                        principalTable: "m_barang",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_transactions_m_pelabuhan_id_pelabuhan",
                        column: x => x.id_pelabuhan,
                        principalTable: "m_pelabuhan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_transactions_m_tarif_kd_tarif",
                        column: x => x.kd_tarif,
                        principalTable: "m_tarif",
                        principalColumn: "kd_tarif",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "m_negara",
                columns: new[] { "id", "kd_negara", "nama" },
                values: new object[,]
                {
                    { 1, "IDN", "Indonesia" },
                    { 2, "SGP", "Singapore" },
                    { 3, "IRQ", "Iraq" },
                    { 4, "MYS", "Malaysia" },
                    { 5, "PHL", "Philippines" }
                });

            migrationBuilder.InsertData(
                table: "m_tarif",
                columns: new[] { "kd_tarif", "tarif_bm" },
                values: new object[,]
                {
                    { 10079000L, 0.10000000000000001 },
                    { 10079111L, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "m_barang",
                columns: new[] { "id", "kd_tarif", "nama" },
                values: new object[,]
                {
                    { 555, 10079000L, "Butiran sorghum" },
                    { 556, 10079000L, "Tembakau" },
                    { 557, 10079000L, "Cengkeh" },
                    { 558, 10079111L, "handphone" },
                    { 559, 10079111L, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "m_pelabuhan",
                columns: new[] { "id", "id_negara", "nama" },
                values: new object[,]
                {
                    { 111, 2, "Jurong" },
                    { 112, 2, "Marina" },
                    { 113, 2, "Keppel" },
                    { 114, 1, "Merak" },
                    { 115, 1, "Batam" },
                    { 116, 3, "Klang" },
                    { 117, 4, "Flous" },
                    { 118, 5, "Rafles" }
                });

            migrationBuilder.InsertData(
                table: "t_transactions",
                columns: new[] { "id", "harga", "id_barang", "id_pelabuhan", "kd_tarif" },
                values: new object[,]
                {
                    { 1, 1000000L, 555, 111, 10079000L },
                    { 2, 1200000L, 556, 112, 10079000L },
                    { 3, 1300000L, 557, 113, 10079000L },
                    { 4, 1400000L, 558, 114, 10079111L },
                    { 5, 1500000L, 559, 115, 10079111L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_barang_kd_tarif",
                table: "m_barang",
                column: "kd_tarif");

            migrationBuilder.CreateIndex(
                name: "IX_m_pelabuhan_id_negara",
                table: "m_pelabuhan",
                column: "id_negara");

            migrationBuilder.CreateIndex(
                name: "IX_t_transactions_id_barang",
                table: "t_transactions",
                column: "id_barang");

            migrationBuilder.CreateIndex(
                name: "IX_t_transactions_id_pelabuhan",
                table: "t_transactions",
                column: "id_pelabuhan");

            migrationBuilder.CreateIndex(
                name: "IX_t_transactions_kd_tarif",
                table: "t_transactions",
                column: "kd_tarif");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_transactions");

            migrationBuilder.DropTable(
                name: "m_barang");

            migrationBuilder.DropTable(
                name: "m_pelabuhan");

            migrationBuilder.DropTable(
                name: "m_tarif");

            migrationBuilder.DropTable(
                name: "m_negara");
        }
    }
}
