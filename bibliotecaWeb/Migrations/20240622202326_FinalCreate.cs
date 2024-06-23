using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApp.Migrations
{
    /// <inheritdoc />
    public partial class FinalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivro");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Livros",
                newName: "LivroId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Autores",
                newName: "AutorId");

            migrationBuilder.CreateTable(
                name: "AutorLivros",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "integer", nullable: false),
                    LivroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivros", x => new { x.AutorId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_AutorLivros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivros_LivroId",
                table: "AutorLivros",
                column: "LivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivros");

            migrationBuilder.RenameColumn(
                name: "LivroId",
                table: "Livros",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Autores",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutoresID = table.Column<int>(type: "integer", nullable: false),
                    LivrosID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => new { x.AutoresID, x.LivrosID });
                    table.ForeignKey(
                        name: "FK_AutorLivro_Autores_AutoresID",
                        column: x => x.AutoresID,
                        principalTable: "Autores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLivro_Livros_LivrosID",
                        column: x => x.LivrosID,
                        principalTable: "Livros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivro_LivrosID",
                table: "AutorLivro",
                column: "LivrosID");
        }
    }
}
