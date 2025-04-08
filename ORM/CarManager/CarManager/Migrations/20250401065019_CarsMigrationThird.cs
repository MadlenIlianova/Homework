using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManager.Migrations
{
    /// <inheritdoc />
    public partial class CarsMigrationThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Cylinders", "FuelType", "Horsepower" },
                values: new object[] { 2, 8, "diesel", 300 });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[] { 2, "Q7", 2018 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "EngineId", "Height", "Lenght", "ModelId", "Seats", "Width" },
                values: new object[] { 2, "Audi", 2, 1.7, 6, 2, 5, 1.2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
