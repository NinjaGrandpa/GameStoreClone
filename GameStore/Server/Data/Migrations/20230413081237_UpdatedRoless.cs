using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRoless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "13eeb1a1-0002-4496-9c01-2d88b29d5fa2", null, "Visitor", "VISITOR" },
                    { "e6de534b-e930-4c5a-a384-0502cd8d803b", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13eeb1a1-0002-4496-9c01-2d88b29d5fa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6de534b-e930-4c5a-a384-0502cd8d803b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2221bc33-c39c-4afb-a543-fcc36b090a2d", null, "Adminstrator", "ADMINSTRATOR" },
                    { "e6170f61-b367-488a-8e58-3a33f6ad7f51", null, "Visitor", "VISITOR" }
                });
        }
    }
}
