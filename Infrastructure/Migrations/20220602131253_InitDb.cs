using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Techpork.Infrastructure.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "circumferences",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    code = table.Column<int>(type: "integer", nullable: false),
                    help_pic_uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_circumferences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "food_sources",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_sources", x => x.id);
                });

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
                name: "micronutrients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    father_id = table.Column<long>(type: "bigint", nullable: true)
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    trainer_id = table.Column<long>(type: "bigint", nullable: true),
                    nutritionist_id = table.Column<long>(type: "bigint", nullable: true),
                    birthday = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    avatar_uri = table.Column<string>(type: "text", nullable: true),
                    height = table.Column<int>(type: "integer", nullable: true),
                    visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_users_nutritionist_id",
                        column: x => x.nutritionist_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_users_trainer_id",
                        column: x => x.trainer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attachments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    last_change = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    uri = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_attachments_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_attachments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_checks", x => x.id);
                    table.ForeignKey(
                        name: "fk_checks_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "diets",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    first_day = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    last_day = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    diff_from_normo = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diets", x => x.id);
                    table.ForeignKey(
                        name: "FK_diets_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_diets_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name_en = table.Column<string>(type: "text", nullable: true),
                    name_it = table.Column<string>(type: "text", nullable: true),
                    carb = table.Column<double>(type: "double precision", nullable: false),
                    pro = table.Column<double>(type: "double precision", nullable: false),
                    fats = table.Column<double>(type: "double precision", nullable: false),
                    kcals = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: true),
                    source_id = table.Column<long>(type: "bigint", nullable: false),
                    sugar = table.Column<double>(type: "double precision", nullable: false),
                    fibers = table.Column<double>(type: "double precision", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    serving_size = table.Column<int>(type: "integer", nullable: false),
                    serving_unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_foods", x => x.id);
                    table.ForeignKey(
                        name: "fk_foods_food_sources_source_id",
                        column: x => x.source_id,
                        principalTable: "food_sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_foods_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pending_follow_requests",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    coach_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pending_follow_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_pending_follow_requests_users_coach_id",
                        column: x => x.coach_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pending_follow_requests_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checks_has_circumferences",
                columns: table => new
                {
                    check_id = table.Column<long>(type: "bigint", nullable: false),
                    circumference_id = table.Column<long>(type: "bigint", nullable: false),
                    measure = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_checks_has_circumferences", x => new { x.check_id, x.circumference_id });
                    table.ForeignKey(
                        name: "fk_checks_has_circumferences_checks_check_id",
                        column: x => x.check_id,
                        principalTable: "checks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_checks_has_circumferences_circumferences_circumference_id",
                        column: x => x.circumference_id,
                        principalTable: "circumferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pics",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    uri = table.Column<string>(type: "text", nullable: false),
                    check_id = table.Column<long>(type: "bigint", nullable: false)
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
                name: "diet_days",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    diet_index = table.Column<int>(type: "integer", nullable: false),
                    diet_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diet_days", x => x.id);
                    table.ForeignKey(
                        name: "fk_diet_days_diets_diet_id",
                        column: x => x.diet_id,
                        principalTable: "diets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    day_index = table.Column<int>(type: "integer", nullable: false),
                    diet_day_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meals", x => x.id);
                    table.ForeignKey(
                        name: "fk_meals_diet_days_diet_day_id",
                        column: x => x.diet_day_id,
                        principalTable: "diet_days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    meal_id = table.Column<long>(type: "bigint", nullable: false),
                    food_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_portions", x => x.id);
                    table.ForeignKey(
                        name: "fk_portions_foods_food_id",
                        column: x => x.food_id,
                        principalTable: "foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_portions_meals_meal_id",
                        column: x => x.meal_id,
                        principalTable: "meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachments_author_id",
                table: "attachments",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_attachments_user_id",
                table: "attachments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_checks_user_id",
                table: "checks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_checks_has_circumferences_circumference_id",
                table: "checks_has_circumferences",
                column: "circumference_id");

            migrationBuilder.CreateIndex(
                name: "IX_circumferences_code",
                table: "circumferences",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_diet_days_diet_id",
                table: "diet_days",
                column: "diet_id");

            migrationBuilder.CreateIndex(
                name: "IX_diets_author_id",
                table: "diets",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_diets_user_id",
                table: "diets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_food_has_micronutrients_micronutrient_id",
                table: "food_has_micronutrients",
                column: "micronutrient_id");

            migrationBuilder.CreateIndex(
                name: "ix_food_has_micronutrients_unit_measure_id",
                table: "food_has_micronutrients",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "ix_food_has_tags_food_tag_id",
                table: "food_has_tags",
                column: "food_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_food_sources_name",
                table: "food_sources",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_food_tags_code",
                table: "food_tags",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_foods_author_id",
                table: "foods",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_foods_name_en_author_id",
                table: "foods",
                columns: new[] { "name_en", "author_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_foods_name_it_author_id",
                table: "foods",
                columns: new[] { "name_it", "author_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_foods_source_id",
                table: "foods",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "ix_meals_diet_day_id",
                table: "meals",
                column: "diet_day_id");

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
                name: "IX_pending_follow_requests_coach_id",
                table: "pending_follow_requests",
                column: "coach_id");

            migrationBuilder.CreateIndex(
                name: "IX_pending_follow_requests_user_id",
                table: "pending_follow_requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_pics_check_id",
                table: "pics",
                column: "check_id");

            migrationBuilder.CreateIndex(
                name: "ix_portions_food_id",
                table: "portions",
                column: "food_id");

            migrationBuilder.CreateIndex(
                name: "ix_portions_meal_id",
                table: "portions",
                column: "meal_id");

            migrationBuilder.CreateIndex(
                name: "IX_unit_measures_name",
                table: "unit_measures",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_nutritionist_id",
                table: "users",
                column: "nutritionist_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_trainer_id",
                table: "users",
                column: "trainer_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachments");

            migrationBuilder.DropTable(
                name: "checks_has_circumferences");

            migrationBuilder.DropTable(
                name: "food_has_micronutrients");

            migrationBuilder.DropTable(
                name: "food_has_tags");

            migrationBuilder.DropTable(
                name: "pending_follow_requests");

            migrationBuilder.DropTable(
                name: "pics");

            migrationBuilder.DropTable(
                name: "portions");

            migrationBuilder.DropTable(
                name: "circumferences");

            migrationBuilder.DropTable(
                name: "micronutrients");

            migrationBuilder.DropTable(
                name: "unit_measures");

            migrationBuilder.DropTable(
                name: "food_tags");

            migrationBuilder.DropTable(
                name: "checks");

            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "food_sources");

            migrationBuilder.DropTable(
                name: "diet_days");

            migrationBuilder.DropTable(
                name: "diets");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
