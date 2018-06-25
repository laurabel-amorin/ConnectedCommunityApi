using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("posts")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }

        [Searchable]
        [Sortable]
        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Searchable]
        [Column("content")]
        public string Content { get; set; }

        [Sortable]
        [Required]
        [Column("group_id")]
        public int GroupId { get; set; }

        [Sortable]
        [Column("member_id")]
        public int MemberId { get; set; }

        [Sortable]
        [Column("group_member_id")]
        public int GroupMemberId { get; set; }

        [Sortable]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Sortable]
        [Column("date_modified")]
        public DateTime? DateModified { get; set; }

        [Sortable]
        [Column("date_archived")]
        public DateTime? DateArchived { get; set; }

        [ForeignKey("GroupMemberId")]
        public GroupMember GroupMember { get; set; }

        public List<Comment> Comments { get; set; }

        public List<PostMedia> Media { get; set; }
    }
}
