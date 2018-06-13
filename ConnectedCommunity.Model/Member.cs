using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        public int Id { get; set; }

        [Sortable]
        public int CommunityId { get; set; }

        [Searchable]
        [Sortable]
        [Required]
        public string Alias { get; set; }

        [Sortable]
        [Required]
        public int UserId { get; set; }

        [Sortable]
        public bool Active { get; set; }

        [Sortable]
        public bool Admin { get; set; }

        [Sortable]
        public DateTime DateCreated { get; set; }

        [ForeignKey("CommunityId")]
        public Community Community { get; set; }

        public List<GroupMember> GroupMemberships { get; set; }
    }
}
