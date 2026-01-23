using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaCatalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaFileHasTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaFileHasTags",
                columns: table => new
                {
                    MediaFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFileHasTags", x => new { x.MediaFileId, x.TagId });
                    table.ForeignKey(
                        name: "FK_MediaFileHasTags_Files_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaFileHasTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFileHasTags_TagId",
                table: "MediaFileHasTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaFileHasTags");
        }
    }
}
