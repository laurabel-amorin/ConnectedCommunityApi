using ConnectedCommunity.Model.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    public class Community
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        [DefaultSortable]
        public int Id { get; set; }

        [Sortable]
        [Required]
        public int SchoolId { get; set; }

        [Required]
        [Searchable]
        [Sortable]
        public string SchoolName { get; set; }

        [Searchable]
        [Sortable]
        public string Name { get; set; }

        [Sortable]
        public DateTime DateCreated { get; set; }

        [Sortable]
        public bool Active { get; set; }

        public List<Group> Groups{ get; set; }

        public List<Member> Members { get; set; }
    }
}
