using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Techpork.Infrastructure.Migrations
{
    public partial class ReactoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food_has_tags");

            migrationBuilder.DropTable(
                name: "pics");

            migrationBuilder.DropTable(
                name: "food_tags");

            migrationBuilder.DropColumn(
                name: "avatar_uri",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "avatar",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_users_height_Range",
                table: "users",
                sql: "height >= 0 AND height <= 300");

            migrationBuilder.AddCheckConstraint(
                name: "CK_users_username_MinLength",
                table: "users",
                sql: "LENGTH(username) >= 3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_users_height_Range",
                table: "users");

            migrationBuilder.DropCheckConstraint(
                name: "CK_users_username_MinLength",
                table: "users");

            migrationBuilder.DropColumn(
                name: "avatar",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "avatar_uri",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "food_tags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pics",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    check_id = table.Column<long>(type: "bigint", nullable: false),
                    uri = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pics", x => x.id);
                    table.ForeignKey(
                        name: "fk_pics_checks_check_id",
                        column: x => x.check_id,
                        principalTable: "checks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "food_has_tags",
                columns: table => new
                {
                    food_id = table.Column<long>(type: "bigint", nullable: false),
                    food_tag_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_has_tags", x => new { x.food_id, x.food_tag_id });
                    table.ForeignKey(
                        name: "fk_food_has_tags_food_tags_food_tag_id",
                        column: x => x.food_tag_id,
                        principalTable: "food_tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_food_has_tags_foods_food_id",
                        column: x => x.food_id,
                        principalTable: "foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_food_has_tags_food_tag_id",
                table: "food_has_tags",
                column: "food_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_food_tags_code",
                table: "food_tags",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pics_check_id",
                table: "pics",
                column: "check_id");
        }
    }
}
