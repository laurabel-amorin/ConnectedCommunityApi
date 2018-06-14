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
    public class PostService
    {
        private readonly IPostRepository postRepo;
        private readonly IPostMediaRepository postMediaRepo;
        private readonly PostVerifier postVerifier;
        private readonly GroupMemberVerifier groupMemberVerifier;
        private readonly MemberVerifier MemberVerifier;

        public PostService(IPostRepository postRepo, IPostMediaRepository postMediaRepo, ICommentRepository commentRepo,
            IGroupMemberRepository groupMemberRepo, IMemberRepository memberRepo)
        {
            this.postRepo = postRepo;
            this.postMediaRepo = postMediaRepo;
            postVerifier = new PostVerifier(postRepo);
            groupMemberVerifier = new GroupMemberVerifier(groupMemberRepo);
            MemberVerifier = new MemberVerifier(memberRepo);
        }
    }

    public class PostOpResult : OpResult
    {
        public Post ResultPost { get; set; }
        public IEnumerable<Post> ResultPosts { get; set; } = new List<Post>();
        public Index<Post, PostParams> IndexResult { get; set; }
        public int Deleted { get; set; }
    }
}
