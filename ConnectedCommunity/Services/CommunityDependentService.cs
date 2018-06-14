using ConnectedCommunity.Components;
using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public abstract class CommunityDependentService
    {
        protected readonly ICommunityRepository communityRepo;
        protected Community community;

        public CommunityDependentService(ICommunityRepository communityRepo)
        {
            this.communityRepo = communityRepo;
        }

        protected async Task<ValidationResult> ValidateCommunity(int communityId)
        {
            community = await communityRepo.FindAsync(communityId);
            if (community == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommunityDoesNotExist));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateActiveCommunity(int communityId)
        {
            var validateCommunityResult = await ValidateCommunity(communityId);
            if (validateCommunityResult != ValidationResult.Success)
            {
                return validateCommunityResult;
            }
            if (!community.Active)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommunityInactive));
            }
            return ValidationResult.Success;
        }
    }
}
