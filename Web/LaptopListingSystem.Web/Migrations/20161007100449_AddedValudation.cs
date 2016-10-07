using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LaptopListingSystem.Web.Migrations
{
    public partial class AddedValudation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptop_Manufacture_ManufactureId",
                table: "Laptop");

            migrationBuilder.DropIndex(
                name: "IX_Laptop_ManufactureId",
                table: "Laptop");

            migrationBuilder.DropColumn(
                name: "ManufactureId",
                table: "Laptop");

            migrationBuilder.DropTable(
                name: "Manufacture");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LaptopId = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Laptop_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LaptopId = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Laptop_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PreserveCreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Laptop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Laptop",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Laptop",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Laptop",
                maxLength: 1000,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Laptop",
                maxLength: 500,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Laptop",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalParts",
                table: "Laptop",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptop_ManufacturerId",
                table: "Laptop",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_LaptopId",
                table: "Comment",
                column: "LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_Name",
                table: "Manufacturer",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_LaptopId",
                table: "Vote",
                column: "LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptop_Manufacturer_ManufacturerId",
                table: "Laptop",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptop_Manufacturer_ManufacturerId",
                table: "Laptop");

            migrationBuilder.DropIndex(
                name: "IX_Laptop_ManufacturerId",
                table: "Laptop");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreserveCreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Laptop");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Laptop");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Laptop");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.CreateTable(
                name: "Manufacture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacture", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "ManufactureId",
                table: "Laptop",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Laptop",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Laptop",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Laptop",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalParts",
                table: "Laptop",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptop_ManufactureId",
                table: "Laptop",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacture_Name",
                table: "Manufacture",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptop_Manufacture_ManufactureId",
                table: "Laptop",
                column: "ManufactureId",
                principalTable: "Manufacture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
