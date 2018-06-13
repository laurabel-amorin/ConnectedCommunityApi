using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public class GroupMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        public int Id { get; set; }

        [Sortable]
        [Required]
        public int MemberId { get; set; }

        [Sortable]
        [Required]
        public int GroupId { get; set; }

        [Sortable]
        public bool Active { get; set; }

        [Sortable]
        public bool Admin { get; set; }

        [Sortable]
        public DateTime DateCreated { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
