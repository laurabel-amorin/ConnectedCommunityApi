using ConnectedCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.IndexParamModels
{
    public class CommunityParams : StandardRepoIndexParams<Community>
    {
        public bool active { get; set; } = true;

        public override IQueryable<Community> ApplyOptions(IQueryable<Community> data)
        {
            data = ApplySearchOptions(data);
            data = ApplyStatusTags(data);
            data = ApplySortAndPaging(data);
            return data;
        }

        public IQueryable<Community> ApplyStatusTags(IQueryable<Community> data)
        {
            data = data.Where(c => (c.Active == active));
            return data;
        }
    }
}
