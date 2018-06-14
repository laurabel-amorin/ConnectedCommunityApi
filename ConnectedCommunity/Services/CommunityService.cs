using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using ConnectedCommunity.Models.IndexParamModels;
using ConnectedCommunity.Models.OutputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public class CommunityService
    {
        private readonly ICommunityRepository communityRepo;
        private readonly CommunityVerifier communityVerifier;

        public CommunityService(ICommunityRepository communityRepo)
        {
            this.communityRepo = communityRepo;
            communityVerifier = new CommunityVerifier(communityRepo);
        }

        public async Task<CommunityOpResult> Get(int communityId)
        {
            var community = await communityRepo.FindAsync(communityId);
            if (community == null)
            {
                return new CommunityOpResult
                {
                    Status = OpStatus.NotFound
                };
            }
            return new CommunityOpResult
            {
                Status = OpStatus.Ok, ResultCommunity=community
            };
        }

        public CommunityOpResult Get(CommunityParams parameters)
        {
            if (parameters == null)
            {
                parameters = new CommunityParams();
            }
            var communities = communityRepo.GetAll();
            var resultCommunities = parameters.ApplyParams(communities);

            return new CommunityOpResult
            {
                Status = OpStatus.Ok,
                IndexResult = new Index<Community, CommunityParams>(resultCommunities, parameters)
            };
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
