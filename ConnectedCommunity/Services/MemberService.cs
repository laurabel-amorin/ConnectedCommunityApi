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
    public interface IMemberService
    {

    }

    public class MemberService:IMemberService
    {
        private readonly IMemberRepository memberRepo;
        private readonly ICommunityVerifier communityVerifier;
        private readonly IMemberVerifier memberVerifier;

        public MemberService(ICommunityRepository communityRepo, IMemberRepository memberRepo)
        {
            this.memberRepo = memberRepo;
            communityVerifier = new CommunityVerifier(communityRepo);
            memberVerifier = new MemberVerifier(memberRepo);
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
