using ConnectedCommunity.Model;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class CommunityInputter:Inputter<CommunityInput, Community>
    {
        private readonly CommunityInput communityInput;
        private readonly int communityId;
        private Community community;

        public CommunityInputter(CommunityInput communityInput):base(communityInput)
        {

        }

        public CommunityInputter(CommunityInput communityInput, int communityId) : base(communityInput, communityId)
        {

        }

        public override ValidationResult ValidateNew()
        {
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            return ValidationResult.Success;
        }

    }
}
