using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public class GroupInput
    {
        public int CommunityId { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public bool Status { get; set; }
    }
}
