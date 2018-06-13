using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        public int Id { get; set; }
        
        [Required]
        [Searchable]
        public string Content { get; set; }

        public string Media { get; set; }

        [Required]
        [Sortable]
        public int PostId { get; set; }

        [Sortable]
        public int? ParentId { get; set; }

        [Sortable]
        public int MemberId { get; set; }

        [Sortable]
        public int GroupMemberId { get; set; }

        [Sortable]
        public DateTime DateCreated { get; set; }

        [Sortable]
        public DateTime? DateModified { get; set; }

        [Sortable]
        public bool Hidden { get; set; }

        [Sortable]
        public bool Private { get; set; }

        [Sortable]
        public int Likes { get; set; }

        [Sortable]
        public int Dislikes { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("ParentId")]
        public Comment ParentComment { get; set; }

        [ForeignKey("GroupMemberId")]
        public GroupMember GroupMember { get; set; }
    }
}
