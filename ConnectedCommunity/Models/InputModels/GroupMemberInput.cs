using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public class GroupMemberInput
    {
        public int MemberId { get; set; }
        public int GroupId { get; set; }
        public bool Admin { get; set; }
    }
}
