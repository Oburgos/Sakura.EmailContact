using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakura.EmailContact.Migrations
{
    public partial class jobidcampaignevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScheduleJobId",
                table: "Campaigns",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleJobId",
                table: "Campaigns");
        }
    }
}
