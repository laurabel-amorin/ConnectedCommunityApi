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
    public class CommunityService
    {
        private readonly ICommunityRepository communityRepo;

        public CommunityService(ICommunityRepository communityRepo)
        {
            this.communityRepo = communityRepo;
        }
    }

    public class CommunityOpResult : OpResult
    {
        public Community ResultCommunity { get; set; }
        public IEnumerable<Community> ResultCommunities { get; set; } = new List<Community>();
        public Index<Community, CommunityParams> IndexResult { get; set; }
        public int Deleted { get; set; }
    }
}
