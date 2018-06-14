using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public class PostInput
    {
        public int MemberId { get; set; }
        [JsonIgnore]
        public int GroupMemberId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Media { get; set; }
        public int GroupId { get; set; }
    }
}
