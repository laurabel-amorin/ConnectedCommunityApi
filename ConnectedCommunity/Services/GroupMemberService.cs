using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using ConnectedCommunity.Models.IndexParamModels;
using ConnectedCommunity.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public class GroupMemberService
    {
        private readonly IGroupMemberRepository groupMemberRepo;
        private readonly IGroupRepository groupRepo;
        private readonly IMemberRepository memberRepo;

        public GroupMemberService(IGroupMemberRepository groupMemberRepo, IGroupRepository groupRepo,IMemberRepository memberRepo)
        {
            this.groupMemberRepo = groupMemberRepo;
            this.groupRepo = groupRepo;
            this.memberRepo = memberRepo;
        }
    }

    public class GroupMemberOpResult : OpResult
    {
        public GroupMember GroupMemberResult { get; set; }
        public IEnumerable<GroupMember> ResultGroupMembers { get; set; } = new List<GroupMember>();
        public Index<GroupMember, GroupMemberParams> IndexResult { get; set; }
        public int Deleted { get; set; }
    }
}
