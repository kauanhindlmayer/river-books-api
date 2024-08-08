using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2b1068c3-0a1a-4ce8-8bbf-cce3ee9dac76"), "Erich Gamma", 48.90m, "Design Patterns" },
                    { new Guid("795a6bbe-b3a4-479e-95c9-288e1c31911f"), "Steve McConnell", 38.00m, "Code Complete" },
                    { new Guid("84e62466-5bcc-4203-8df1-f07238f4aff7"), "Martin Fowler", 50.00m, "Patterns of Enterprise Application Architecture" },
                    { new Guid("9334c5ea-92cf-4edf-b263-8e954fba47bf"), "Robert C. Martin", 45.50m, "Clean Code" },
                    { new Guid("a5d6c8c4-6647-4161-9cc3-5c1037e14bad"), "Martin Fowler", 40.00m, "Refactoring" },
                    { new Guid("b9bf5ec9-9559-45e2-a7ba-0dac14bbba06"), "Michael Feathers", 32.00m, "Working Effectively with Legacy Code" },
                    { new Guid("bfdef945-0bc2-4686-8c99-2bf6f29aab18"), "Andrew Hunt", 42.00m, "The Pragmatic Programmer" },
                    { new Guid("cb57263c-2775-4eb4-b665-6c65f7dcf8b1"), "Eric Evans", 55.90m, "Domain-Driven Design" },
                    { new Guid("d8bfaa84-a12e-43ea-a2fa-b9a09bef5f30"), "Kent Beck", 45.00m, "Test Driven Development: By Example" },
                    { new Guid("e5204137-616a-43f7-93d8-3a9ab0cae56d"), "Robert C. Martin", 55.00m, "Clean Architecture" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "Books");
        }
    }
}
