using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("post_media")]
    public class PostMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("post_id")]
        public int PostId { get; set; }

        [Column("media")]
        public string Media { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
