using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishDeliveryWebSite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    achivment = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    categoryName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DishDescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calories = table.Column<int>(type: "int", nullable: true),
                    protein = table.Column<int>(type: "int", nullable: true),
                    fats = table.Column<int>(type: "int", nullable: true),
                    carbohydrates = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishDescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    surName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    email = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    address = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    dishName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dishes.categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Dishes.id",
                        column: x => x.id,
                        principalTable: "DishDescription",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FoodProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    unitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_FoodProducts.unitId",
                        column: x => x.unitId,
                        principalTable: "Unit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    dishList = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    deliveryDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order.userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DishesFoodProducts",
                columns: table => new
                {
                    dishId = table.Column<int>(type: "int", nullable: false),
                    foodProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DishesFo__4FAEFD83985E6EA6", x => new { x.dishId, x.foodProductId });
                    table.ForeignKey(
                        name: "FK_DishesFoodProducts.dishId",
                        column: x => x.dishId,
                        principalTable: "Dishes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DishesFoodProducts.foodProductId",
                        column: x => x.foodProductId,
                        principalTable: "FoodProducts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MenuOrder",
                columns: table => new
                {
                    dishId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MenuOrde__B66B6096F1139BAF", x => new { x.dishId, x.orderId });
                    table.ForeignKey(
                        name: "FK_MenuOrder.dishId",
                        column: x => x.dishId,
                        principalTable: "Dishes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_MenuOrder.orderId",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_categoryId",
                table: "Dishes",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DishesFoodProducts_foodProductId",
                table: "DishesFoodProducts",
                column: "foodProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodProducts_unitId",
                table: "FoodProducts",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuOrder_orderId",
                table: "MenuOrder",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishesFoodProducts");

            migrationBuilder.DropTable(
                name: "MenuOrder");

            migrationBuilder.DropTable(
                name: "FoodProducts");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "DishDescription");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
