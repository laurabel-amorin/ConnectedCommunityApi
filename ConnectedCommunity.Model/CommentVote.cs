using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public enum VoteType
    {
        Like, Dislike
    }

    [Table("comment_votes")]
    public class CommentVote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("type")]
        public VoteType Type { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Column("group_member_id")]
        public int GroupMemberId { get; set; }

        [Column("member_id")]
        public int MemberId { get; set; }

        [Required]
        [Column("comment_id")]
        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        [ForeignKey("GroupMemberId")]
        public GroupMember GroupMember { get; set; }
    }
}
