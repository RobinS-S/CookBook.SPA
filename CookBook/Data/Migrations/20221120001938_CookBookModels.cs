using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CookBook.Data.Migrations
{
    public partial class CookBookModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false),
                    short_description = table.Column<string>(type: "character varying(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "character varying(512)", unicode: false, maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipe_category",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_category", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "recipe_ingredient_amount",
                schema: "cook_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    ingredient_id = table.Column<long>(type: "bigint", nullable: false),
                    amount = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_ingredient_amount", x => new { x.recipe_id, x.id });
                    table.ForeignKey(
                        name: "fk_recipe_ingredient_amount_ingredients_ingredient_id",
                        column: x => x.ingredient_id,
                        principalSchema: "cook_book",
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recipe_ingredient_amount_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalSchema: "cook_book",
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_recipe_category_category_id",
                schema: "cook_book",
                table: "recipe_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_category_recipe_id",
                schema: "cook_book",
                table: "recipe_category",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_ingredient_amount_ingredient_id",
                schema: "cook_book",
                table: "recipe_ingredient_amount",
                column: "ingredient_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe_category",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "recipe_ingredient_amount",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "ingredients",
                schema: "cook_book");

            migrationBuilder.DropTable(
                name: "recipes",
                schema: "cook_book");
        }
    }
}
