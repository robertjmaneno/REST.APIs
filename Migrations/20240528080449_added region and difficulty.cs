using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST.APIs.Migrations
{
    /// <inheritdoc />
    public partial class addedregionanddifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficuilty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("122bed92-bf29-4999-8c8b-1eb360a5f44c"), "Hard" },
                    { new Guid("1adcc4ef-379d-40bb-9e7c-71dcd7586a0c"), "Easy" },
                    { new Guid("8ebc17c8-3fd9-4765-afb7-26f79ee279fb"), "Very Hard" },
                    { new Guid("9544d9fb-4c4f-4469-a224-e134d10080a8"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficuilty",
                keyColumn: "Id",
                keyValue: new Guid("122bed92-bf29-4999-8c8b-1eb360a5f44c"));

            migrationBuilder.DeleteData(
                table: "Difficuilty",
                keyColumn: "Id",
                keyValue: new Guid("1adcc4ef-379d-40bb-9e7c-71dcd7586a0c"));

            migrationBuilder.DeleteData(
                table: "Difficuilty",
                keyColumn: "Id",
                keyValue: new Guid("8ebc17c8-3fd9-4765-afb7-26f79ee279fb"));

            migrationBuilder.DeleteData(
                table: "Difficuilty",
                keyColumn: "Id",
                keyValue: new Guid("9544d9fb-4c4f-4469-a224-e134d10080a8"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));
        }
    }
}
