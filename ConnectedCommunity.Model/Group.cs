using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public enum Membership
    {
        Open, ByInvite, Default
    }

    [Table("groups")]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Sortable]
        [Column("community_id")]
        public int CommunityId { get; set; }

        [Sortable]
        [Column("creator_id")]
        public int? CreatorId { get; set; }

        [Searchable]
        [Sortable]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Searchable]
        [Column("description")]
        public string Description { get; set; }

        [Sortable]
        [Column("membership")]
        public Membership Membership { get; set; }

        [Sortable]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Sortable]
        [Column("date_modified")]
        public DateTime? DateModified { get; set; }

        [Sortable]
        [Column("date_archived")]
        public DateTime? DateArchived { get; set; }

        [Sortable]
        [Column("active")]
        public bool Active { get; set; }

        [ForeignKey("CommunityId")]
        public Community Community { get; set; }

        [ForeignKey("CreatorId")]
        public Member Member { get; set; }

        public List<GroupMember> GroupMembers { get; set; }

        public List<Post> Posts { get; set; }

        [NotMapped]
        public int Size { get; set; }
    }
}
