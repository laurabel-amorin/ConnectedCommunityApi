using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public class MemberInput
    {
        public int CommunityId { get; set; }
        public string Alias { get; set; }
        public int UserId { get; set; }
        public bool Admin { get; set; }
    }
}
