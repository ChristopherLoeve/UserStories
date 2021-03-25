using Microsoft.EntityFrameworkCore.Migrations;

namespace UserStories.Migrations
{
    public partial class UserStories_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessValue",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Fixed",
                table: "Cards",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoryPoints",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TaskDone",
                table: "Cards",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserStoryId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserStoryId",
                table: "Cards",
                column: "UserStoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Cards_UserStoryId",
                table: "Cards",
                column: "UserStoryId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Cards_UserStoryId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserStoryId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BusinessValue",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Column",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Fixed",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "StoryPoints",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TaskDone",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserStoryId",
                table: "Cards");
        }
    }
}
