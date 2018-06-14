using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IPostMediaRepository:IRepository<PostMedia>{
    }

    public class PostMediaRepository: Repository<PostMedia>, IPostMediaRepository
    {
        public PostMediaRepository(AppDataContext context):base(context)
        {
        }
    }
}
