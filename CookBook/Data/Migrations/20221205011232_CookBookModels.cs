using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CookBook.Data.Migrations
{
    public partial class CookBookModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "cook_book",
                table: "asp_net_user_tokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                schema: "cook_book",
                table: "asp_net_user_tokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "provider_key",
                schema: "cook_book",
                table: "asp_net_user_logins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                schema: "cook_book",
                table: "asp_net_user_logins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(128)", unicode: false, maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(512)", unicode: false, maxLength: 512, nullable: false),
                    suitable_for = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient_entry",
                schema: "cook_book",
                columns: table => new
                {
                    recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit = table.Column<string>(type: "character varying(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredient_entry", x => new { x.recipe_id, x.id });
                    table.ForeignKey(
                        name: "fk_ingredient_entry_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalSchema: "cook_book",
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "preparation_step",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_preparation_step", x => new { x.recipe_id, x.id });
                    table.ForeignKey(
                        name: "fk_preparation_step_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalSchema: "cook_book",
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_category",
                schema: "cook_book",
                columns: table => new
                {
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    recipe_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_category", x => new { x.category_id, x.recipe_id });
                    table.ForeignKey(
                        name: "fk_recipe_category_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "cook_book",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recipe_category_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalSchema: "cook_book",
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_recipe_category_recipe_id",
                schema: "cook_book",
                table: "recipe_category",
                column: "recipe_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient_entry",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "preparation_step",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "recipe_category",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "recipes",
                schema: "cook_book");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "cook_book",
                table: "asp_net_user_tokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                schema: "cook_book",
                table: "asp_net_user_tokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "provider_key",
                schema: "cook_book",
                table: "asp_net_user_logins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                schema: "cook_book",
                table: "asp_net_user_logins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
