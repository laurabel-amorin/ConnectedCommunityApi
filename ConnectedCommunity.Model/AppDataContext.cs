using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<GroupMember> GroupMembers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<CommentMedia> CommentMedia { get; set; }
        public virtual DbSet<PostMedia> PostMedia { get; set; }
        public virtual DbSet<CommentVote> CommentVotes { get; set; }
        public virtual DbSet<GroupInvite> GroupInvites { get; set; }

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

            //post media
            modelBuilder.Entity<PostMedia>().HasIndex(pmedia => pmedia.Id);
            modelBuilder.Entity<PostMedia>().HasIndex(pmedia => pmedia.PostId).IsUnique(false);

            //comment media
            modelBuilder.Entity<CommentMedia>().HasIndex(cmedia => cmedia.Id);
            modelBuilder.Entity<CommentMedia>().HasIndex(cmedia => cmedia.CommentId).IsUnique(false);

            //comment votes
            modelBuilder.Entity<CommentVote>().HasIndex(cvote => cvote.CommentId).IsUnique(false);
            modelBuilder.Entity<CommentVote>().HasIndex(cvote => cvote.GroupMemberId).IsUnique(false);

            //group invites
            modelBuilder.Entity<GroupInvite>().HasIndex(gi => gi.GroupId).IsUnique(false);
            modelBuilder.Entity<GroupInvite>().HasIndex(gi => gi.MemberId).IsUnique(false);
        }
    }
}
