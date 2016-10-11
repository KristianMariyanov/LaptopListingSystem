using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopListingSystem.Web.Migrations
{
    public partial class updatedDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Laptop_LaptopId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptop_Manufacturer_ManufacturerId",
                table: "Laptop");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Laptop_LaptopId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_AspNetUsers_UserId",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laptop",
                table: "Laptop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Vote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laptops",
                table: "Laptop",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Laptops_LaptopId",
                table: "Comment",
                column: "LaptopId",
                principalTable: "Laptop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Manufacturers_ManufacturerId",
                table: "Laptop",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Laptops_LaptopId",
                table: "Vote",
                column: "LaptopId",
                principalTable: "Laptop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Vote",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_LaptopId",
                table: "Vote",
                newName: "IX_Votes_LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturer_Name",
                table: "Manufacturer",
                newName: "IX_Manufacturers_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Laptop_ManufacturerId",
                table: "Laptop",
                newName: "IX_Laptops_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_LaptopId",
                table: "Comment",
                newName: "IX_Comments_LaptopId");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "Laptop",
                newName: "Laptops");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Laptops_LaptopId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Manufacturers_ManufacturerId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Laptops_LaptopId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laptops",
                table: "Laptops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Votes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laptop",
                table: "Laptops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Laptop_LaptopId",
                table: "Comments",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptop_Manufacturer_ManufacturerId",
                table: "Laptops",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Laptop_LaptopId",
                table: "Votes",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                newName: "IX_Vote_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_LaptopId",
                table: "Votes",
                newName: "IX_Vote_LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                newName: "IX_Manufacturer_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Laptops_ManufacturerId",
                table: "Laptops",
                newName: "IX_Laptop_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_LaptopId",
                table: "Comments",
                newName: "IX_Comment_LaptopId");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "Laptops",
                newName: "Laptop");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");
        }
    }
}
