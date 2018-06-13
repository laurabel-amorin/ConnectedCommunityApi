using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface ICommunityRepository:IRepository<Community>{
    }

    public class CommunityRepository: Repository<Community>, ICommunityRepository
    {
        public CommunityRepository(AppDataContext context):base(context)
        {
        }
    }
}
