using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [Searchable]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Sortable]
        [Column("post_id")]
        public int PostId { get; set; }

        [Sortable]
        [Column("parent_id")]
        public int? ParentId { get; set; }

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
        [Column("hidden")]
        public bool Hidden { get; set; }

        [Sortable]
        [Column("deleted")]
        public bool Deleted { get; set; }

        [Sortable]
        [Column("private")]
        public bool Private { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("ParentId")]
        public Comment ParentComment { get; set; }

        [ForeignKey("GroupMemberId")]
        public GroupMember GroupMember { get; set; }

        public List<CommentMedia> Media { get; set; }
    }
}
