using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("communities")]
    public class Community
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        [DefaultSortable]
        [Column("id")]
        public int Id { get; set; }

        [Sortable]
        [Required]
        [Column("school_id")]
        public int SchoolId { get; set; }

        [Required]
        [Searchable]
        [Sortable]
        [Column("school_name")]
        public string SchoolName { get; set; }

        [Searchable]
        [Sortable]
        [Column("name")]
        public string Name { get; set; }

        [Sortable]
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Sortable]
        [Column("active")]
        public bool Active { get; set; }

        public List<Group> Groups{ get; set; }

        public List<Member> Members { get; set; }
    }
}
