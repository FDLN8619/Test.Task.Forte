using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Task.Api.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddEStatusStringMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EStatusString",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EStatusString",
                table: "Tasks");
        }
    }
}
