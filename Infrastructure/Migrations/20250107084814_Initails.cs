using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "DesignationId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 101, 201, "john.doe@example.com", "John Doe" },
                    { 2, 102, 202, "jane.smith@example.com", "Jane Smith" },
                    { 3, 103, 203, "emily.johnson@example.com", "Emily Johnson" },
                    { 4, 104, 204, "michael.brown@example.com", "Michael Brown" },
                    { 5, 105, 205, "sarah.davis@example.com", "Sarah Davis" },
                    { 6, 106, 206, "david.wilson@example.com", "David Wilson" },
                    { 7, 107, 207, "laura.martinez@example.com", "Laura Martinez" },
                    { 8, 108, 208, "james.anderson@example.com", "James Anderson" },
                    { 9, 109, 209, "linda.thomas@example.com", "Linda Thomas" },
                    { 10, 110, 210, "robert.moore@example.com", "Robert Moore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
