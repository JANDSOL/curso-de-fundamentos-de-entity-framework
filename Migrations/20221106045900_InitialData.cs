using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj_tareas_categ.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("2642c11b-6367-4494-b0c9-9c0785be95a1"), "Actividades cotidianas del hogar.", "Hogar" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("2642c11b-6367-4494-b0c9-9c0785be95a2"), "Universidad" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "Title" },
                values: new object[] { new Guid("2642c11b-6367-4494-b0c9-9c0785be95b1"), new Guid("2642c11b-6367-4494-b0c9-9c0785be95a1"), "Limpiar Cuarto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("2642c11b-6367-4494-b0c9-9c0785be95a2"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("2642c11b-6367-4494-b0c9-9c0785be95b1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("2642c11b-6367-4494-b0c9-9c0785be95a1"));
        }
    }
}
