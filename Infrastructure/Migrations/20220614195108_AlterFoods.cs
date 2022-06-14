using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Techpork.Infrastructure.Migrations
{
    public partial class AlterFoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food_has_micronutrients");

            migrationBuilder.DropTable(
                name: "micronutrients");

            migrationBuilder.DropTable(
                name: "unit_measures");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "foods");

            migrationBuilder.AlterColumn<double>(
                name: "sugar",
                table: "foods",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "pro",
                table: "foods",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "kcals",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "fibers",
                table: "foods",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "fats",
                table: "foods",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "carb",
                table: "foods",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "calcium",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dha",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "epa",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "magnesium",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "potassium",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sodium",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vitamin_a",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vitamin_b12",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vitamin_c",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vitamin_d",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vitamin_e",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "zinc",
                table: "foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calcium",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "dha",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "epa",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "magnesium",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "potassium",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "sodium",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "vitamin_a",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "vitamin_b12",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "vitamin_c",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "vitamin_d",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "vitamin_e",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "zinc",
                table: "foods");

            migrationBuilder.AlterColumn<double>(
                name: "sugar",
                table: "foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "pro",
                table: "foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "kcals",
                table: "foods",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "fibers",
                table: "foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "fats",
                table: "foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "carb",
                table: "foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "foods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "micronutrients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    father_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_micronutrients", x => x.id);
                    table.ForeignKey(
                        name: "fk_micronutrients_micronutrients_father_id",
                        column: x => x.father_id,
                        principalTable: "micronutrients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unit_measures",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit_measures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "food_has_micronutrients",
                columns: table => new
                {
                    food_id = table.Column<long>(type: "bigint", nullable: false),
                    micronutrient_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_measure_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_has_micronutrients", x => new { x.food_id, x.micronutrient_id });
                    table.ForeignKey(
                        name: "fk_food_has_micronutrients_foods_food_id",
                        column: x => x.food_id,
                        principalTable: "foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_food_has_micronutrients_micronutrients_micronutrient_id",
                        column: x => x.micronutrient_id,
                        principalTable: "micronutrients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_food_has_micronutrients_unit_measures_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalTable: "unit_measures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_food_has_micronutrients_micronutrient_id",
                table: "food_has_micronutrients",
                column: "micronutrient_id");

            migrationBuilder.CreateIndex(
                name: "ix_food_has_micronutrients_unit_measure_id",
                table: "food_has_micronutrients",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "ix_micronutrients_father_id",
                table: "micronutrients",
                column: "father_id");

            migrationBuilder.CreateIndex(
                name: "IX_micronutrients_name",
                table: "micronutrients",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unit_measures_name",
                table: "unit_measures",
                column: "name",
                unique: true);
        }
    }
}
