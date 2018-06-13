using ConnectedCommunity.Components;
using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
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
        public CommunityInputter(CommunityInput communityInput):base(communityInput)
        {

        }

        public CommunityInputter(CommunityInput communityInput, Community currentCommunity) : base(communityInput, currentCommunity)
        {

        }

        public override ValidationResult ValidateNew()
        {
            if (string.IsNullOrEmpty(input.SchoolName))
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.SchoolNameRequired));
            }

            if (input.SchoolId==0)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.SchoolIdRequired));
            }
            processedInput = new Community
            {
                SchoolId = input.SchoolId,
                SchoolName = input.SchoolName,
                Name = string.IsNullOrEmpty(input.Name) ? input.SchoolName : input.Name
            };
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            if (!string.IsNullOrEmpty(input.Name))
            {
                current.Name = input.Name;
            }
            if (!string.IsNullOrEmpty(input.SchoolName))
            {
                current.SchoolName = input.SchoolName;
            }
            processedInput = current;
            return ValidationResult.Success;
        }

    }
}
