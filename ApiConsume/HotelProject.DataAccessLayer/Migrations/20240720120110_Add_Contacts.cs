using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class Add_Contacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Contacts",
               columns: table => new
               {
                   ContactID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Contacts", x => x.ContactID);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Contacts");
        }
    }
}
