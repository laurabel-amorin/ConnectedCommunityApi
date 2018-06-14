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
    public class MemberService:CommunityDependentService
    {
        private readonly IMemberRepository memberRepo;

        public MemberService(ICommunityRepository communityRepo, IMemberRepository memberRepo):base(communityRepo)
        {
            this.memberRepo = memberRepo;
        }
    }

    public class MemberOpResult : OpResult
    {
        public Member ResultMember { get; set; }
        public IEnumerable<Member> ResultMembers { get; set; } = new List<Member>();
        public Index<Member, MemberParams> IndexResult { get; set; }
        public int Deleted { get; set; }
    }
}
