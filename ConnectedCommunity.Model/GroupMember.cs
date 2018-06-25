﻿using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("group_members")]
    public class GroupMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }

        [Sortable]
        [Required]
        [Column("member_id")]
        public int MemberId { get; set; }

        [Sortable]
        [Required]
        [Column("group_id")]
        public int GroupId { get; set; }

        [Sortable]
        [Column("active")]
        public bool Active { get; set; }

        [Sortable]
        [Column("admin")]
        public bool Admin { get; set; }

        [Sortable]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
