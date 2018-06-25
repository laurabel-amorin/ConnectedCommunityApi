using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConnectedCommunity.Model
{
    [Table("comment_media")]
    public class CommentMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("comment_id")]
        public int CommentId { get; set; }

        [Column("media")]
        public string Media { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
    }
}
