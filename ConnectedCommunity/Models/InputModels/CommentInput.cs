using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public class CommentInput
    {
        public int MemberId { get; set; }
        public int GroupId { get; set; }
        public string Content { get; set; }
        public string Media { get; set; }
        public int PostId { get; set; }
        public int ParentId { get; set; }
        public bool Private { get; set; }
    }
}
