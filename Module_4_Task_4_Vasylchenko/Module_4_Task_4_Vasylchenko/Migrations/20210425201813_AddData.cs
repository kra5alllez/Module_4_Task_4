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
                "('t5', 'Alinaa')");
            migrationBuilder.Sql("INSERT INTO Title (Name) " +
                "VALUES ('tBaron')," +
                "('tItalia')," +
                "('tEskobaro')," +
                "('tPhephe')," +
                "('tAlinaa')");
            migrationBuilder.Sql("INSERT INTO Employee (FirstName, LastName, HiredDate, DateOfBirth, OfficeId, TitleId)" +
                "VALUES('eProject1', 'ghlgu11', GETDATE(), GETDATE(), (SELECT OfficeId From Office WHERE Location = 'Baron'), (SELECT TitleId From Title WHERE Name = 'tBaron'))," +
                "('eProject2', 'yujkm12', GETDATE(), GETDATE(), (SELECT OfficeId From Office WHERE Location = 'Italia'), (SELECT TitleId From Title WHERE Name = 'tItalia'))," +
                "('eProject3', 'fhgmj13', GETDATE(), GETDATE(), (SELECT OfficeId From Office WHERE Location = 'Eskobaro'), (SELECT TitleId From Title WHERE Name = 'tEskobaro'))," +
                "('eProject4', 'hfgj14', GETDATE(), GETDATE(), (SELECT OfficeId From Office WHERE Location = 'Phephe'), (SELECT TitleId From Title WHERE Name = 'tPhephe'))," +
                "('eProject5', 'fhjy15', GETDATE(), GETDATE(), (SELECT OfficeId From Office WHERE Location = 'Alinaa'), (SELECT TitleId From Title WHERE Name = 'tAlinaa'))");
            migrationBuilder.Sql("INSERT INTO EmployeeProject (Rate, StartedDate, EmployeeId, ProjectId) " +
                "VALUES (1, GETDATE(), (SELECT EmployeeId From Employee WHERE FirstName = 'eProject1'), (SELECT ProjectId From Project WHERE Name = 'Project1'))," +
                "(2, GETDATE(), (SELECT EmployeeId From Employee WHERE FirstName = 'eProject2'), (SELECT ProjectId From Project WHERE Name = 'Project2'))," +
                "(3, GETDATE(), (SELECT EmployeeId From Employee WHERE FirstName = 'eProject3'), (SELECT ProjectId From Project WHERE Name = 'Project3'))," +
                "(4, GETDATE(), (SELECT EmployeeId From Employee WHERE FirstName = 'eProject3'), (SELECT ProjectId From Project WHERE Name = 'Project3'))," +
                "(5, GETDATE(), (SELECT EmployeeId From Employee WHERE FirstName = 'eProject5'), (SELECT ProjectId From Project WHERE Name = 'Project5'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Office WHERE Title IN ('t1', 't2', 't3', 't4', 't5')");
            migrationBuilder.Sql("DELETE FROM Title WHERE Name IN ('tBaron', 'tItalia', 'tEskobaro', 'tPhephe', 'tAlinaa')");
            migrationBuilder.Sql("DELETE FROM Employee WHERE FirstName IN ('eProject1', 'eProject2', 'eProject3', 'eProject4', 'eProject5')");
            migrationBuilder.Sql("DELETE FROM EmployeeProject WHERE Rate IN ('1', '2', '3', '4', '5')");
        }
    }
}
