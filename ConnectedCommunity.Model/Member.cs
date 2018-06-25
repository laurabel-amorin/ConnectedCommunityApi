using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("members")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }

        [Sortable]
        [Column("community_id")]
        public int CommunityId { get; set; }

        [Searchable]
        [Sortable]
        [Required]
        [Column("alias")]
        public string Alias { get; set; }

        [Sortable]
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Sortable]
        [Column("active")]
        public bool Active { get; set; }

        [Sortable]
        [Column("admin")]
        public bool Admin { get; set; }

        [Sortable]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("CommunityId")]
        public Community Community { get; set; }

        public List<GroupMember> GroupMemberships { get; set; }
    }
}
