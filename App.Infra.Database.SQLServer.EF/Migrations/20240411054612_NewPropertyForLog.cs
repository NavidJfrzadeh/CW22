using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Database.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertyForLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Requests_CarRequestId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "CarRequestId",
                table: "Logs",
                newName: "CarBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_CarRequestId",
                table: "Logs",
                newName: "IX_Logs_CarBrandId");

            migrationBuilder.AddColumn<string>(
                name: "CarPlateNumber",
                table: "Logs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CarProduceDate",
                table: "Logs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                maxLength: 250,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "Logs",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Brands_CarBrandId",
                table: "Logs",
                column: "CarBrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Brands_CarBrandId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CarPlateNumber",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CarProduceDate",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "CarBrandId",
                table: "Logs",
                newName: "CarRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_CarBrandId",
                table: "Logs",
                newName: "IX_Logs_CarRequestId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Logs",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Requests_CarRequestId",
                table: "Logs",
                column: "CarRequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
