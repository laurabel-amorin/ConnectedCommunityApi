using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IPostRepository:IRepository<Post>{
    }

    public class PostRepository: Repository<Post>, IPostRepository
    {
        public PostRepository(AppDataContext context):base(context)
        {
        }
    }
}
