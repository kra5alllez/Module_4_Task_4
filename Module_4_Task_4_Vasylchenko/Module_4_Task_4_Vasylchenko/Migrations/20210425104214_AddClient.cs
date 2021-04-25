using Microsoft.EntityFrameworkCore.Migrations;

namespace Module_4_Task_4_Vasylchenko.Migrations
{
    public partial class AddClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql("INSERT INTO Client (FirstName, LastName, Country, Email) " +
                "VALUES ('Jon', 'Baron', 'India', 'indianemai@gmail.com')," +
                "('Pen', 'Vsem', 'Italia', 'nreshrdtj@gmail.com')," +
                "('Pedro', 'Eskobaro', 'Brasil', 'fdhhfgmjgf@gmail.com')," +
                "('Darek', 'Phephe', 'Poland', 'iukddxrfh@gmail.com')," +
                "('Alina', 'Alinaa', 'Ukrain', 'dfhdsfgsai@gmail.com')" +
                "INSERT INTO Project (Name, Budget, StartedDate, ClientId)" +
                "VALUES('Project1', 11, GETDATE(), (SELECT ClientId From Client WHERE Email = 'indianemai@gmail.com'))," +
                "('Project2', 12, GETDATE(), (SELECT ClientId From Client WHERE Email = 'fdhhfgmjgf@gmail.com'))," +
                "('Project3', 13, GETDATE(), (SELECT ClientId From Client WHERE Email = 'fdhhfgmjgf@gmail.com'))," +
                "('Project4', 14, GETDATE(), (SELECT ClientId From Client WHERE Email = 'iukddxrfh@gmail.com'))," +
                "('Project5', 15, GETDATE(), (SELECT ClientId From Client WHERE Email = 'dfhdsfgsai@gmail.com'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Project WHERE Name IN ('Project1', 'Project2', 'Project3', 'Project4', 'Project5')");
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
