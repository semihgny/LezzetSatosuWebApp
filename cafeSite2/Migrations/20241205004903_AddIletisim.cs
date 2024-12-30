using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafeSite2.Migrations
{
    /// <inheritdoc />
    public partial class AddIletisim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "iletisim",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iletisim", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "iletisim");
        }
    }
}
