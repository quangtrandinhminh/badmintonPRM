using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Add_booking_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slots_BookingOrders_BookingOrdersId",
                table: "Slots");

            migrationBuilder.DropIndex(
                name: "IX_Slots_BookingOrdersId",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "BookingOrdersId",
                table: "Slots");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Yards",
                newName: "YardId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Slots",
                newName: "SlotId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookingOrders",
                newName: "BookingOrderId");

            migrationBuilder.CreateTable(
                name: "BookingOrdersSlot",
                columns: table => new
                {
                    BookingOrdersBookingOrderId = table.Column<int>(type: "integer", nullable: false),
                    SlotsSlotId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOrdersSlot", x => new { x.BookingOrdersBookingOrderId, x.SlotsSlotId });
                    table.ForeignKey(
                        name: "FK_BookingOrdersSlot_BookingOrders_BookingOrdersBookingOrderId",
                        column: x => x.BookingOrdersBookingOrderId,
                        principalTable: "BookingOrders",
                        principalColumn: "BookingOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingOrdersSlot_Slots_SlotsSlotId",
                        column: x => x.SlotsSlotId,
                        principalTable: "Slots",
                        principalColumn: "SlotId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrdersSlot_SlotsSlotId",
                table: "BookingOrdersSlot",
                column: "SlotsSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingOrdersSlot");

            migrationBuilder.RenameColumn(
                name: "YardId",
                table: "Yards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SlotId",
                table: "Slots",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingOrderId",
                table: "BookingOrders",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BookingOrdersId",
                table: "Slots",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kQTq9fpzpWBuCGiZSnjSHe7Mr6MSMGkCnY/1i6d9UYm1t2yKIvBzy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$7azVhznE4PpBtnTYo5r0OOFgrng2nqD5EqRYXxcXjDBauYiOjg5xy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$iVxrAOTXTojM3LejyKWoa..tVtbHSMxomwvUgAkd4WAozx.bkSvaq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$mUv6nwdEsTqdtM/oqV0vPugu.0PaYMheiVuuaEej0UuH7sbXsoDUW");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_BookingOrdersId",
                table: "Slots",
                column: "BookingOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_BookingOrders_BookingOrdersId",
                table: "Slots",
                column: "BookingOrdersId",
                principalTable: "BookingOrders",
                principalColumn: "Id");
        }
    }
}
