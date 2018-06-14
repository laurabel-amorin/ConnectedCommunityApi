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
        private readonly GroupMemberVerifier groupMemberVerifier;
        private readonly GroupVerifier groupVerifier;
        private readonly MemberVerifier memberVerifier;

        public GroupMemberService(IGroupMemberRepository groupMemberRepo, IGroupRepository groupRepo,IMemberRepository memberRepo)
        {
            this.groupMemberRepo = groupMemberRepo;
            groupVerifier = new GroupVerifier(groupRepo);
            memberVerifier = new MemberVerifier(memberRepo);
            groupMemberVerifier = new GroupMemberVerifier(groupMemberRepo);
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
