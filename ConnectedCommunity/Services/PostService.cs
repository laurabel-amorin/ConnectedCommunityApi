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
        protected ICommentRepository commentRepo;

        public PostService(IPostRepository postRepo, ICommentRepository commentRepo)
        {
            this.postRepo = postRepo;
            this.commentRepo = commentRepo;
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
