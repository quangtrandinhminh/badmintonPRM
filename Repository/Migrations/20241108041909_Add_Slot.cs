using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Add_Slot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "SlotId", "EndTime", "IsActive", "Price", "StartTime", "YardId" },
                values: new object[,]
                {
                    { 1, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 1 },
                    { 2, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 1 },
                    { 3, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 1 },
                    { 4, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 1 },
                    { 5, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 1 },
                    { 6, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 2 },
                    { 7, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 2 },
                    { 8, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 2 },
                    { 9, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 2 },
                    { 10, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 2 },
                    { 11, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 3 },
                    { 12, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 3 },
                    { 13, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 3 },
                    { 14, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 3 },
                    { 15, new TimeOnly(0, 0, 0), true, 100000.0, new TimeOnly(0, 0, 0), 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Y7MreXbBTN1M62isBRpb7euXD7Zo9UswuQQl0fSqKXHGgniZf3lOq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$HQaANF/ibmy.avYSe8R9k.JxHhUWF90hJB6efNZPTthdIkygvMOby");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$l7MsLy8rb7IXyqR8.rT78.a3qenNV0iGnpUD2TUb96Is4VDmbA7qm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$/WKCi/k7XHwP8xiL7qSoHuPjgqSvoLzoWxwQkmSCqFWhslEFX5S6a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zlO4gMh/wf.cy5o5farxn.uvO7EtlBEcmhgE1KGY1fw98UvBJYwOS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$70cVqqwW26T7NitMn/ezKu.3gefIiaQx1jAAWQGkPbwcusB5DBwIm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Jy1XWuMKX2aQKzXzlAv.A.B91md7we6R6T4ePiIxe5CzT5TR98NwW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$M5KCwF7RyyOH2FGIF0Y9oeMLUZQm/68rubyua8LHFDFBcT1JpHXoO");
        }
    }
}
