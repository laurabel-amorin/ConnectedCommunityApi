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

    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        public int Id { get; set; }

        [Required]
        [Sortable]
        public int CommunityId { get; set; }

        [Sortable]
        public int? CreatorId { get; set; }

        [Searchable]
        [Sortable]
        [Required]
        public string Name { get; set; }

        [Searchable]
        public string Description { get; set; }

        [Sortable]
        public Membership Membership { get; set; }

        [Sortable]
        public DateTime DateCreated { get; set; }

        [Sortable]
        public DateTime? DateModified { get; set; }

        [Sortable]
        public DateTime? DateArchived { get; set; }

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
