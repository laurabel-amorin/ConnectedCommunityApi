using ConnectedCommunity.Components;
using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using ConnectedCommunity.Models.InputModels;
using ConnectedCommunity.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class MemberInputter:Inputter<MemberInput, Member, IMemberRepository>
    {
        public MemberInputter(IMemberRepository memberRepo, MemberInput memberInput):base(memberRepo, memberInput)
        {

        }

        public MemberInputter(IMemberRepository memberRepo, MemberInput memberInput, Member currentMember)
            :base(memberRepo, memberInput, currentMember)
        {

        }

        public override ValidationResult ValidateNew()
        {
            string alias = input.Alias;
            
            if (!UserService.VerifyUser(input.UserId))
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.InvalidMemberUserId));
            }

            if (string.IsNullOrEmpty(alias))
            {
                alias = UserService.GetDefaultAlias();
            }

            processedInput = new Member
            {
                Alias=alias,
                UserId=input.UserId,
                CommunityId=input.CommunityId,
                Admin=input.Admin,
                DateCreated=DateTime.UtcNow
            };

            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            string alias = input.Alias;
            
            if (!string.IsNullOrEmpty(alias))
            {
                current.Alias = alias;
            }

            processedInput = current;
            return ValidationResult.Success;
        }

    }
}
