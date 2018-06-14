using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Helpers
{
    public static class StringHelper
    {
        public static string GetContractedText(string text)
        {
            string contractedLengthString = "50";
            int contractedLength = 0;
            if(!int.TryParse(contractedLengthString, out contractedLength))
            {
                contractedLength = 50;
            }
            if (text.Length == contractedLength)
            {
                return text;
            }

            return text.Substring(0, contractedLength) + "...";

        }
    }
}
