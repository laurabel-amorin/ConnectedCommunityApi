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
    public interface IGroupService
    {

    }

    public class GroupService:IGroupService
    {
        private readonly IGroupRepository groupRepo;
        private readonly ICommunityVerifier communityVerifier;
        private readonly IGroupVerifier groupVerifier;
        private readonly IMemberVerifier memberVerifier;
        private readonly IGroupMemberVerifier groupMemberVerifier;

        public GroupService(ICommunityRepository communityRepo, IGroupRepository groupRepo, IMemberRepository memberRepo,
            IGroupMemberRepository groupMemberRepo)
        {
            this.groupRepo = groupRepo;
            communityVerifier = new CommunityVerifier(communityRepo);
            groupVerifier = new GroupVerifier(groupRepo);
            memberVerifier = new MemberVerifier(memberRepo);
            groupMemberVerifier = new GroupMemberVerifier(groupMemberRepo);
        }
    }

    public class GroupOpResult : OpResult
    {
        public Group ResultGroup { get; set; }
        public IEnumerable<Group> ResultGroups { get; set; } = new List<Group>();
        public Index<Group, GroupParams> IndexResult { get; set; }
        public int Deleted { get; set; }
    }
}
