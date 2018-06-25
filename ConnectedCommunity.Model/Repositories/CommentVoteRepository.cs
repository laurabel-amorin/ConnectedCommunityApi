using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface ICommentVoteRepository:IRepository<CommentVote>
    {
    }

    public class CommentVoteRepository : Repository<CommentVote>, ICommentVoteRepository
    {
        public CommentVoteRepository(AppDataContext context):base(context)
        {
        }
    }
}
