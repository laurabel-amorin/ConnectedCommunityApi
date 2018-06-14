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
    public class CommunityInputter:Inputter<CommunityInput, Community, ICommunityRepository>
    {
        public CommunityInputter(ICommunityRepository communityRepo, CommunityInput communityInput)
            :base(communityRepo, communityInput)
        {

        }

        public CommunityInputter(ICommunityRepository communityRepo, CommunityInput communityInput, Community currentCommunity)
            :base(communityRepo, communityInput, currentCommunity)
        {

        }

        public override async Task<ValidationResult> ValidateNew()
        {
            if (string.IsNullOrEmpty(input.SchoolName))
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommunitySchoolNameRequired));
            }

            if (input.SchoolId==0)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommunitySchoolIdRequired));
            }

            var duplicateNames = await repo.GetAsync(c => c.Name == input.Name);
            if (duplicateNames.Any())
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.DuplicateCommunityName));
            }

            processedInput = new Community
            {
                SchoolId = input.SchoolId,
                SchoolName = input.SchoolName,
                Name = string.IsNullOrEmpty(input.Name) ? input.SchoolName : input.Name,
                DateCreated=DateTime.UtcNow
            };
            return ValidationResult.Success;
        }

        public override async Task<ValidationResult> ValidateUpdate()
        {
            if (!string.IsNullOrEmpty(input.Name))
            {
                var duplicateNames = await repo.GetAsync(c => (c.Name == input.Name)&&(c.Id!=current.Id));
                if (duplicateNames.Any())
                {
                    return new ValidationResult(MessageStrings.GetMessage(MessageStrings.DuplicateCommunityName));
                }
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
