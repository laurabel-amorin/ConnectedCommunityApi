using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConnectedCommunity.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "communities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    school_id = table.Column<int>(nullable: false),
                    school_name = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    community_id = table.Column<int>(nullable: false),
                    alias = table.Column<string>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false),
                    admin = table.Column<bool>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_members_communities_community_id",
                        column: x => x.community_id,
                        principalTable: "communities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    community_id = table.Column<int>(nullable: false),
                    creator_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    membership = table.Column<int>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: true),
                    date_archived = table.Column<DateTime>(nullable: true),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_groups_communities_community_id",
                        column: x => x.community_id,
                        principalTable: "communities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groups_members_creator_id",
                        column: x => x.creator_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_invites",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    member_id = table.Column<int>(nullable: false),
                    group_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_invites", x => x.id);
                    table.ForeignKey(
                        name: "FK_group_invites_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_group_invites_members_member_id",
                        column: x => x.member_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_members",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    member_id = table.Column<int>(nullable: false),
                    group_id = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false),
                    admin = table.Column<bool>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_group_members_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_group_members_members_member_id",
                        column: x => x.member_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    group_id = table.Column<int>(nullable: false),
                    member_id = table.Column<int>(nullable: false),
                    group_member_id = table.Column<int>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: true),
                    date_archived = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posts_group_members_group_member_id",
                        column: x => x.group_member_id,
                        principalTable: "group_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    content = table.Column<string>(nullable: false),
                    post_id = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: true),
                    member_id = table.Column<int>(nullable: false),
                    group_member_id = table.Column<int>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: true),
                    hidden = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    @private = table.Column<bool>(name: "private", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_group_members_group_member_id",
                        column: x => x.group_member_id,
                        principalTable: "group_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_comments_parent_id",
                        column: x => x.parent_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_media",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    post_id = table.Column<int>(nullable: false),
                    media = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_media", x => x.id);
                    table.ForeignKey(
                        name: "FK_post_media_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment_media",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    comment_id = table.Column<int>(nullable: false),
                    media = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_media", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_media_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment_votes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type = table.Column<int>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    group_member_id = table.Column<int>(nullable: false),
                    member_id = table.Column<int>(nullable: false),
                    comment_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_votes", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_votes_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_votes_group_members_group_member_id",
                        column: x => x.group_member_id,
                        principalTable: "group_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_media_comment_id",
                table: "comment_media",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_media_id",
                table: "comment_media",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_votes_comment_id",
                table: "comment_votes",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_votes_group_member_id",
                table: "comment_votes",
                column: "group_member_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_group_member_id",
                table: "comments",
                column: "group_member_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_id",
                table: "comments",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_parent_id",
                table: "comments",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_post_id",
                table: "comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_communities_id",
                table: "communities",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_communities_school_id",
                table: "communities",
                column: "school_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_invites_group_id",
                table: "group_invites",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_invites_member_id",
                table: "group_invites",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_members_active",
                table: "group_members",
                column: "active");

            migrationBuilder.CreateIndex(
                name: "IX_group_members_group_id",
                table: "group_members",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_members_id",
                table: "group_members",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_group_members_member_id",
                table: "group_members",
                column: "member_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_groups_community_id",
                table: "groups",
                column: "community_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_creator_id",
                table: "groups",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_date_archived",
                table: "groups",
                column: "date_archived");

            migrationBuilder.CreateIndex(
                name: "IX_groups_id",
                table: "groups",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_membership",
                table: "groups",
                column: "membership");

            migrationBuilder.CreateIndex(
                name: "IX_members_active",
                table: "members",
                column: "active");

            migrationBuilder.CreateIndex(
                name: "IX_members_community_id",
                table: "members",
                column: "community_id");

            migrationBuilder.CreateIndex(
                name: "IX_members_id",
                table: "members",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_members_user_id",
                table: "members",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_post_media_id",
                table: "post_media",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_post_media_post_id",
                table: "post_media",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_date_archived",
                table: "posts",
                column: "date_archived");

            migrationBuilder.CreateIndex(
                name: "IX_posts_group_id",
                table: "posts",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_group_member_id",
                table: "posts",
                column: "group_member_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_id",
                table: "posts",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_media");

            migrationBuilder.DropTable(
                name: "comment_votes");

            migrationBuilder.DropTable(
                name: "group_invites");

            migrationBuilder.DropTable(
                name: "post_media");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "group_members");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "communities");
        }
    }
}
