using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Add_YardImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Yards");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Yards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenTime",
                table: "Yards",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Yards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Yards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseTime",
                table: "Yards",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Yards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "YardImages",
                columns: table => new
                {
                    YardImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: false),
                    YardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YardImages", x => x.YardImageId);
                    table.ForeignKey(
                        name: "FK_YardImages_Yards_YardId",
                        column: x => x.YardId,
                        principalTable: "Yards",
                        principalColumn: "YardId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Yards",
                columns: new[] { "YardId", "Address", "CloseTime", "Description", "IsActive", "Name", "OpenTime", "OwnerId", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "123 Phan Văn Trị, Gò Vấp, Hồ Chí Minh", new TimeOnly(22, 0, 0), "Sân bóng đẹp, sạch sẽ, thoáng đãng", true, "Yard 1", new TimeOnly(7, 0, 0), 3, 1 },
                    { 2, "124 Phan Văn Trị, Gò Vấp, Hồ Chí Minh", new TimeOnly(22, 0, 0), "Sân bóng đẹp, sạch sẽ, thoáng đãng", true, "Yard 2", new TimeOnly(7, 0, 0), 3, 1 },
                    { 3, "123 Phan Văn Trị, Gò Vấp, Hồ Chí Minh", new TimeOnly(22, 0, 0), "Sân bóng đẹp, sạch sẽ, thoáng đãng", true, "Yard 3", new TimeOnly(7, 0, 0), 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_YardImages_YardId",
                table: "YardImages",
                column: "YardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YardImages");

            migrationBuilder.DeleteData(
                table: "Yards",
                keyColumn: "YardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Yards",
                keyColumn: "YardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Yards",
                keyColumn: "YardId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Yards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenTime",
                table: "Yards",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Yards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Yards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseTime",
                table: "Yards",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Yards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Yards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zm9xrzPQKhh/YDMtYzgoSOxGt5.DsT1RqqyJaLpW36Ox2ESliTe/m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$TMjTKDwjLlOgg9KysW71TO4XEQ2F2FMPh0EujiPXYHsJs6OILQ4Di");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$e5FyAV5w0qZIrFnPnxQRzegwcU8m7A/aoJfC38gF0Eint9B.89a2W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$5s8Bm.aXth1vCftZs1qLMOKZlpVp629lx8mtfMUq2TX2e0O75Cr3.");
        }
    }
}
