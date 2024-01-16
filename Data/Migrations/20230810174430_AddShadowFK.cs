using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddShadowFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder is null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Courses_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Courses_Id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkill_Courses_CourseId",
                table: "CourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Users_Id",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_Users_Id",
                table: "PersonalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PersonalInformation_Id",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Courses_Id",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseSkill",
                newName: "CoursesId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Videos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Videos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInformationId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Logins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseId",
                table: "Videos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginId",
                table: "Users",
                column: "LoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PersonalInformationId",
                table: "Skills",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CourseId",
                table: "Books",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CourseId",
                table: "Articles",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Courses_CourseId",
                table: "Articles",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Courses_CourseId",
                table: "Books",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkill_Courses_CoursesId",
                table: "CourseSkill",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_Users_UserId",
                table: "PersonalInformation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_PersonalInformation_PersonalInformationId",
                table: "Skills",
                column: "PersonalInformationId",
                principalTable: "PersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Logins_LoginId",
                table: "Users",
                column: "LoginId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Courses_CourseId",
                table: "Videos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder is null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Courses_CourseId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Courses_CourseId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkill_Courses_CoursesId",
                table: "CourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_Users_UserId",
                table: "PersonalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PersonalInformation_PersonalInformationId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Logins_LoginId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Courses_CourseId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_CourseId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Users_LoginId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PersonalInformationId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_Books_CourseId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CourseId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonalInformationId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseSkill",
                newName: "CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Videos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Logins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Courses_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Courses_Id",
                table: "Books",
                column: "Id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkill_Courses_CourseId",
                table: "CourseSkill",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Users_Id",
                table: "Logins",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_Users_Id",
                table: "PersonalInformation",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_PersonalInformation_Id",
                table: "Skills",
                column: "Id",
                principalTable: "PersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Courses_Id",
                table: "Videos",
                column: "Id",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
