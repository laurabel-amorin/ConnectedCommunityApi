using ConnectedCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.IndexParamModels
{
    public class GroupParams : StandardRepoIndexParams<Group>
    {
        public Membership? membership { get; set; }
        public bool archived { get; set; } = false;

        public override IQueryable<Group> ApplyOptions(IQueryable<Group> data)
        {
            data = ApplySearchOptions(data);
            data = ApplyStatusTags(data);
            data = ApplySortAndPaging(data);
            return data;
        }

        public IQueryable<Group> ApplyStatusTags(IQueryable<Group> data)
        {
            data = data.Where(g => ((g.DateArchived != null) == archived)&&((membership == null || (g.Membership == membership.Value))));
            return data;
        }
    }
}
