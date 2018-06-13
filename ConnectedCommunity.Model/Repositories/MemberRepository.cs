using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IMemberRepository:IRepository<Member>{
    }

    public class MemberRepository: Repository<Member>, IMemberRepository
    {
        public MemberRepository(AppDataContext context):base(context)
        {
        }
    }
}
