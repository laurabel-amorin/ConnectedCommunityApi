using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public enum InviteType
    {
        Requested, Issued
    }

    public enum InviteStatus
    {
        Pending, Accepted, Declined, Finalized
    }

    [Table("group_invites")]
    public class GroupInvite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }

        [Column("type")]
        public InviteType Type { get; set; }

        [Column("status")]
        public InviteStatus Status { get; set; }

        [Sortable]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Sortable]
        [Required]
        [Column("member_id")]
        public int MemberId { get; set; }

        [Required]
        [Column("group_id")]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }
    }
}
