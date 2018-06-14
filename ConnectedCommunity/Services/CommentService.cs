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
    public class CommentService
    {
        private readonly ICommentRepository commentRepo;
        private readonly CommentVerifier commentVerifier;
        private readonly PostVerifier postVerifier;
        private readonly GroupMemberVerifier groupMemberVerifier;
        private readonly MemberVerifier MemberVerifier;


        public CommentService(ICommentRepository commentRepo, IPostRepository postRepo, IGroupMemberRepository groupMemberRepo, 
            IMemberRepository memberRepo)
        {
            this.commentRepo = commentRepo;
            commentVerifier = new CommentVerifier(commentRepo);
            postVerifier = new PostVerifier(postRepo);
            groupMemberVerifier = new GroupMemberVerifier(groupMemberRepo);
            MemberVerifier = new MemberVerifier(memberRepo);
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
