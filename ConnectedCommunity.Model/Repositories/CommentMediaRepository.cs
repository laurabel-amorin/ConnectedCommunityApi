using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface ICommentMediaRepository:IRepository<CommentMedia>{
    }

    public class CommentMediaRepository: Repository<Comment>, ICommentRepository
    {
        public CommentMediaRepository(AppDataContext context):base(context)
        {
        }
    }
}
