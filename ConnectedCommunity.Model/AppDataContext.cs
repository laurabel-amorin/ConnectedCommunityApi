﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConnectedCommunity.Model
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
           : base(options)
        {

        }

        public virtual DbSet<Community> Communities { get; set; }
        public virtual DbSet<Post> Members { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Post> Comments { get; set; }
        public virtual DbSet<Post> GroupMembers { get; set; }
        public virtual DbSet<Post> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //communites
            modelBuilder.Entity<Community>().HasIndex(community => community.Id);
            modelBuilder.Entity<Community>().HasIndex(community => community.SchoolId).IsUnique();

            //posts
            modelBuilder.Entity<Post>().HasIndex(post => post.Id);
            modelBuilder.Entity<Post>().HasIndex(post => post.GroupId).IsUnique(false);
            modelBuilder.Entity<Post>().HasIndex(post => post.GroupMemberId).IsUnique(false);
            modelBuilder.Entity<Post>().HasIndex(post => post.DateArchived).IsUnique(false);

            //groups
            modelBuilder.Entity<Group>().HasIndex(group => group.Id);
            modelBuilder.Entity<Group>().HasIndex(group => group.Membership).IsUnique(false);
            modelBuilder.Entity<Group>().HasIndex(group => group.DateArchived).IsUnique(false);

            //group members
            modelBuilder.Entity<GroupMember>().HasIndex(groupMember => groupMember.Id);
            modelBuilder.Entity<GroupMember>().HasIndex(groupMember => groupMember.MemberId).IsUnique();
            modelBuilder.Entity<GroupMember>().HasIndex(groupMember => groupMember.Active).IsUnique(false);

            //comments
            modelBuilder.Entity<Comment>().HasIndex(comment => comment.Id);
            modelBuilder.Entity<Comment>().HasIndex(comment => comment.ParentId).IsUnique(false);
            modelBuilder.Entity<Comment>().HasIndex(comment => comment.GroupMemberId).IsUnique(false);
            modelBuilder.Entity<Comment>().HasIndex(comment => comment.PostId).IsUnique(false);


            //members
            modelBuilder.Entity<Member>().HasIndex(member => member.Id);
            modelBuilder.Entity<Member>().HasIndex(member => member.UserId).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(member => member.Active).IsUnique(false);
        }
    }
}
