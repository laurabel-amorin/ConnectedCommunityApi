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
    public class GroupService:CommunityDependentService
    {
        private readonly IGroupRepository groupRepo;

        public GroupService(ICommunityRepository communityRepo, IGroupRepository groupRepo) : base(communityRepo)
        {
            this.groupRepo = groupRepo;
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
