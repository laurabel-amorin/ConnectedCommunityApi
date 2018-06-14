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
        private ICommentRepository commentRepo;
        private readonly IGroupRepository groupRepo;
        private readonly IGroupMemberRepository groupMemberRepo;
        private readonly IMemberRepository memberRepo;

        public PostService(IPostRepository postRepo, ICommentRepository commentRepo, IGroupRepository groupRepo,
            IGroupMemberRepository groupMemberRepo, IMemberRepository memberRepo)
        {
            this.postRepo = postRepo;
            this.commentRepo = commentRepo;
            this.groupRepo = groupRepo;
            this.groupMemberRepo = groupMemberRepo;
            this.memberRepo = memberRepo;
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
