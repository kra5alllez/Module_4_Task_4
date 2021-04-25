using Microsoft.EntityFrameworkCore.Migrations;

namespace Module_4_Task_4_Vasylchenko.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Office (Title, Location) " +
               "VALUES ('t1', 'Baron')," +
               "('t2', 'Italia')," +
               "('t3', 'Eskobaro')," +
               "('t4', 'Phephe')," +
               "('t5', 'Alinaa')" +
               "INSERT INTO Title (Name) " +
               "VALUES ('tBaron')," +
               "('tItalia')," +
               "('tEskobaro')," +
               "('tPhephe')," +
               "('tAlinaa')"+
               "INSERT INTO Employee (FirstName, LastName, HiredDate, DateOfBirth, OfficeId, TitleId)" +
               "VALUES('Project1', 'ghlgu11', GETDATE(), GETDATE(), 1, 1)," +
               "('Project2', 'yujkm12', GETDATE(), GETDATE(), 2, 2)," +
               "('Project3', 'fhgmj13', GETDATE(), GETDATE(), 3, 4)," +
               "('Project4', 'hfgj14', GETDATE(), GETDATE(), 4, 4)," +
               "('Project5', 'fhjy15', GETDATE(), GETDATE(), 5, 5)" +
               "INSERT INTO EmployeeProject (Rate, StartedDate, EmployeeId, ProjectId) " +
               "VALUES (1, GETDATE(), 1, 1)," +
               "(2, GETDATE(), 2, 2)," +
               "(3, GETDATE(), 3, 3)," +
               "(4, GETDATE(), 4, 4)," +
               "(5, GETDATE(), 5, 5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
