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
    public interface ICommentService
    {

    }

    public class CommentService:ICommentService
    {
        private readonly ICommentRepository commentRepo;
        private readonly ICommentMediaRepository commentMediaRepo;
        private readonly ICommentVerifier commentVerifier;
        private readonly IPostVerifier postVerifier;
        private readonly IGroupMemberVerifier groupMemberVerifier;
        private readonly IMemberVerifier MemberVerifier;


        public CommentService(ICommentRepository commentRepo, ICommentMediaRepository commentMediaRepo, IPostRepository postRepo, IGroupMemberRepository groupMemberRepo, 
            IMemberRepository memberRepo)
        {
            this.commentRepo = commentRepo;
            this.commentMediaRepo = commentMediaRepo;
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
