using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChat.Infra.Migrations
{
    public partial class AddingMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkIdSender = table.Column<int>(type: "int", nullable: false),
                    FkIdReceiver = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "varchar(MAX)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
