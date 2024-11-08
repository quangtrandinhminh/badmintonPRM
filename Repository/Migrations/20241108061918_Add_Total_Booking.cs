using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Add_Total_Booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "BookingOrders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$3n13NKBKfuRPCv76cZEbQOVncTObIpuv6ftwCNlOeueMYFoSHc95C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$m0W4nBIaBy6GBe97vQrVxeRkuTwNXK/OqSv27PtdSUa5PDbu0vCbq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$GoX9ePn5nlXVpyR1xdxXO.pOmk8LtCtsBcZDxyc1CVWf.Hqe03vwq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$bzDTYfIxEB4CTQfjoanyCew/xTGdx9Ui7JOsyKCL4lInk3FhVoN4q");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "BookingOrders");

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
