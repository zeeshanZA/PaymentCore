using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    PaymentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.PaymentRequestId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequestState",
                columns: table => new
                {
                    PaymentRequestStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentRequestId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequestState", x => x.PaymentRequestStateId);
                    table.ForeignKey(
                        name: "FK_PaymentRequestState_PaymentRequests_PaymentRequestId",
                        column: x => x.PaymentRequestId,
                        principalTable: "PaymentRequests",
                        principalColumn: "PaymentRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequestState_PaymentRequestId",
                table: "PaymentRequestState",
                column: "PaymentRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRequestState");

            migrationBuilder.DropTable(
                name: "PaymentRequests");
        }
    }
}
