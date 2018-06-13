using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConnectedCommunity.Model.Migrations
{
    public partial class ForumModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Communities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Communities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Communities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommunityId = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommunityId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Membership = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    DateArchived = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Member_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MemberId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMember_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Heading = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Media = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    GroupMemberId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    DateArchived = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_GroupMember_GroupMemberId",
                        column: x => x.GroupMemberId,
                        principalTable: "GroupMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: false),
                    Media = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    GroupMemberId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    Private = table.Column<bool>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_GroupMember_GroupMemberId",
                        column: x => x.GroupMemberId,
                        principalTable: "GroupMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_Id",
                table: "Communities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_SchoolId",
                table: "Communities",
                column: "SchoolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_GroupMemberId",
                table: "Comment",
                column: "GroupMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Id",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                table: "Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CommunityId",
                table: "Group",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatorId",
                table: "Group",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_DateArchived",
                table: "Group",
                column: "DateArchived");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Id",
                table: "Group",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Membership",
                table: "Group",
                column: "Membership");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Active",
                table: "GroupMember",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_GroupId",
                table: "GroupMember",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Id",
                table: "GroupMember",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_MemberId",
                table: "GroupMember",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_Active",
                table: "Member",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_Member_CommunityId",
                table: "Member",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_Id",
                table: "Member",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserId",
                table: "Member",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_DateArchived",
                table: "Post",
                column: "DateArchived");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupId",
                table: "Post",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMemberId",
                table: "Post",
                column: "GroupMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Id",
                table: "Post",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Communities_Id",
                table: "Communities");

            migrationBuilder.DropIndex(
                name: "IX_Communities_SchoolId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Communities");
        }
    }
}
