using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class RenamingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_group_users_groups_GroupsId",
                table: "group_users");

            migrationBuilder.DropForeignKey(
                name: "FK_group_users_users_MembersId",
                table: "group_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_group_users",
                table: "group_users");

            migrationBuilder.RenameTable(
                name: "group_users",
                newName: "GroupUsers");

            migrationBuilder.RenameColumn(
                name: "second_name",
                table: "users",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "lessons",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "start_time",
                table: "lessons",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "lessons",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "day",
                table: "lessons",
                newName: "DayType");

            migrationBuilder.RenameColumn(
                name: "schedule_format",
                table: "groups",
                newName: "ScheduleFormat");

            migrationBuilder.RenameIndex(
                name: "IX_group_users_MembersId",
                table: "GroupUsers",
                newName: "IX_GroupUsers_MembersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers",
                columns: new[] { "GroupsId", "MembersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_groups_GroupsId",
                table: "GroupUsers",
                column: "GroupsId",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_users_MembersId",
                table: "GroupUsers",
                column: "MembersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_groups_GroupsId",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_users_MembersId",
                table: "GroupUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers");

            migrationBuilder.RenameTable(
                name: "GroupUsers",
                newName: "group_users");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "users",
                newName: "second_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "lessons",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "lessons",
                newName: "start_time");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "lessons",
                newName: "end_time");

            migrationBuilder.RenameColumn(
                name: "DayType",
                table: "lessons",
                newName: "day");

            migrationBuilder.RenameColumn(
                name: "ScheduleFormat",
                table: "groups",
                newName: "schedule_format");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUsers_MembersId",
                table: "group_users",
                newName: "IX_group_users_MembersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_group_users",
                table: "group_users",
                columns: new[] { "GroupsId", "MembersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_group_users_groups_GroupsId",
                table: "group_users",
                column: "GroupsId",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_group_users_users_MembersId",
                table: "group_users",
                column: "MembersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
