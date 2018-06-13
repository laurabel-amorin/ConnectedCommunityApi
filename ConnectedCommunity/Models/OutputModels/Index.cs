using ConnectedCommunity.Models.IndexParamModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.OutputModels
{
    public class Index<T, TO> where TO : IndexParams<T>
    {
        [JsonProperty(Order = 2)]
        public IEnumerable<T> Data { get; set; }

        [JsonProperty(Order = 1)]
        public TO Params { get; set; }

        public Index(IEnumerable<T> data, TO parameters = null)
        {
            Data = data;
            Params = parameters;
        }
    }
}
