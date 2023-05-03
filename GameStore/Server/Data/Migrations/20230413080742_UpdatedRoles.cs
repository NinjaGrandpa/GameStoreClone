using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2221bc33-c39c-4afb-a543-fcc36b090a2d", null, "Adminstrator", "ADMINSTRATOR" },
                    { "e6170f61-b367-488a-8e58-3a33f6ad7f51", null, "Visitor", "VISITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2221bc33-c39c-4afb-a543-fcc36b090a2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6170f61-b367-488a-8e58-3a33f6ad7f51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fab57a0-7db3-43c6-8ef6-89528a6d8af4", null, "Visitor", "VISITOR" },
                    { "d20d55dc-bc76-42bf-955e-e01bc2d85c15", null, "Adminstrator", "ADMINSTRATOR" }
                });
        }
    }
}
