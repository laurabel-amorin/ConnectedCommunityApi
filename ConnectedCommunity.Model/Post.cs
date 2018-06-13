using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        public int Id { get; set; }

        [Searchable]
        [Sortable]
        [Required]
        public string Heading { get; set; }

        [Searchable]
        public string Content { get; set; }

        public string Media { get; set; }

        [Sortable]
        [Required]
        public int GroupId { get; set; }

        [Sortable]
        public int MemberId { get; set; }

        [Sortable]
        public int GroupMemberId { get; set; }

        [Sortable]
        public DateTime DateCreated { get; set; }

        [Sortable]
        public DateTime? DateModified { get; set; }

        [Sortable]
        public DateTime? DateArchived { get; set; }

        [ForeignKey("GroupMemberId")]
        public GroupMember GroupMember { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
