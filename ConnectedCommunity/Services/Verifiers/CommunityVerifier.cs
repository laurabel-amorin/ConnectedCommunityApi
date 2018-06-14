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
    public class CommunityVerifier
    {
        private readonly ICommunityRepository communityRepo;
        public Community Community;

        public CommunityVerifier(ICommunityRepository communityRepo)
        {
            this.communityRepo = communityRepo;
        }

        public async Task<ValidationResult> VerifyCommunity(int communityId)
        {
            Community = await communityRepo.FindAsync(communityId);
            if (Community == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommunityDoesNotExist));
            }
            return ValidationResult.Success;
        }

        public async Task<ValidationResult> VerifyActiveCommunity(int communityId)
        {
            var validateCommunityResult = await VerifyCommunity(communityId);
            if (validateCommunityResult != ValidationResult.Success)
            {
                return validateCommunityResult;
            }
            if (!Community.Active)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommunityInactive));
            }
            return ValidationResult.Success;
        }
    }
}
