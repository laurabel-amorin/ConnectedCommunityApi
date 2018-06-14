using ConnectedCommunity.Components;
using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using ConnectedCommunity.Models.IndexParamModels;
using ConnectedCommunity.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public class CommentService:PostDependentService
    {
        private readonly ICommentRepository commentRepo;

        public CommentService(ICommentRepository commentRepo, IPostRepository postRepo, IGroupRepository groupRepo, 
            IGroupMemberRepository groupMemberRepo, IMemberRepository memberRepo):base(postRepo, groupRepo, memberRepo, groupMemberRepo)
        {
            this.commentRepo = commentRepo;
        }

    }

    public class CommentOpResult : OpResult
    {
        public Comment ResultComment { get; set; }
        public IEnumerable<Comment> ResultComments { get; set; } = new List<Comment>();
        public Index<Comment, CommentParams> IndexResult { get; set; }
        public int Deleted { get; set; }
    }
}
