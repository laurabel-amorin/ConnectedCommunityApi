﻿// <auto-generated />
using System;
using ConnectedCommunity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConnectedCommunity.Model.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ConnectedCommunity.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("Dislikes");

                    b.Property<int>("GroupMemberId");

                    b.Property<bool>("Hidden");

                    b.Property<int>("Likes");

                    b.Property<string>("Media");

                    b.Property<int>("MemberId");

                    b.Property<int?>("ParentId");

                    b.Property<int>("PostId");

                    b.Property<bool>("Private");

                    b.HasKey("Id");

                    b.HasIndex("GroupMemberId");

                    b.HasIndex("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Community", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<int>("SchoolId");

                    b.Property<string>("SchoolName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("SchoolId")
                        .IsUnique();

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommunityId");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime?>("DateArchived");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<int>("Membership");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DateArchived");

                    b.HasIndex("Id");

                    b.HasIndex("Membership");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Admin");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("GroupId");

                    b.Property<int>("MemberId");

                    b.HasKey("Id");

                    b.HasIndex("Active");

                    b.HasIndex("GroupId");

                    b.HasIndex("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("GroupMember");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Admin");

                    b.Property<string>("Alias")
                        .IsRequired();

                    b.Property<int>("CommunityId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Active");

                    b.HasIndex("CommunityId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Member");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime?>("DateArchived");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("GroupId");

                    b.Property<int>("GroupMemberId");

                    b.Property<string>("Heading")
                        .IsRequired();

                    b.Property<string>("Media");

                    b.Property<int>("MemberId");

                    b.HasKey("Id");

                    b.HasIndex("DateArchived");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupMemberId");

                    b.HasIndex("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Comment", b =>
                {
                    b.HasOne("ConnectedCommunity.Model.GroupMember", "GroupMember")
                        .WithMany("Comments")
                        .HasForeignKey("GroupMemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConnectedCommunity.Model.Comment", "ParentComment")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("ConnectedCommunity.Model.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Group", b =>
                {
                    b.HasOne("ConnectedCommunity.Model.Community", "Community")
                        .WithMany("Groups")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConnectedCommunity.Model.Member", "Member")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("ConnectedCommunity.Model.GroupMember", b =>
                {
                    b.HasOne("ConnectedCommunity.Model.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConnectedCommunity.Model.Member", "Member")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Member", b =>
                {
                    b.HasOne("ConnectedCommunity.Model.Community", "Community")
                        .WithMany("Members")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConnectedCommunity.Model.Post", b =>
                {
                    b.HasOne("ConnectedCommunity.Model.Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConnectedCommunity.Model.GroupMember", "GroupMember")
                        .WithMany("Posts")
                        .HasForeignKey("GroupMemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}