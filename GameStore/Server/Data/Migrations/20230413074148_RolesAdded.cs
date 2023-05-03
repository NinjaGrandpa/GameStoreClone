using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34b67c8b-ffc8-432c-b898-8081709e7774");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2378819-f070-458f-a0c8-a9915de3675a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fab57a0-7db3-43c6-8ef6-89528a6d8af4", null, "Visitor", "VISITOR" },
                    { "d20d55dc-bc76-42bf-955e-e01bc2d85c15", null, "Adminstrator", "ADMINSTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fab57a0-7db3-43c6-8ef6-89528a6d8af4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d20d55dc-bc76-42bf-955e-e01bc2d85c15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34b67c8b-ffc8-432c-b898-8081709e7774", null, "Adminstrator", "ADMINSTRATPR" },
                    { "e2378819-f070-458f-a0c8-a9915de3675a", null, "Visitor", "VISITOR" }
                });
        }
    }
}
