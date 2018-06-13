using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface ICommentRepository:IRepository<Comment>{
    }

    public class CommentRepository: Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDataContext context):base(context)
        {
        }
    }
}
