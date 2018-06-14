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
    public class GroupInputter:Inputter<GroupInput, Group, IGroupRepository>
    {
        public GroupInputter(IGroupRepository groupRepo, GroupInput groupInput)
            :base(groupRepo, groupInput)
        {

        }

        public GroupInputter(IGroupRepository groupRepo, GroupInput groupInput, Group currentGroup) 
            :base(groupRepo, groupInput, currentGroup)
        {

        }

        public override ValidationResult ValidateNew()
        {
            if (string.IsNullOrEmpty(input.Name))
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupNameRequired));
            }

            var duplicateNames = repo.Get(c => c.Name == input.Name);
            if (duplicateNames.Any())
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.DuplicateGroupName));
            }

            processedInput = new Group
            {
                Name=input.Name,
                CommunityId=input.CommunityId,
                Description=input.Description,
                Membership=input.Membership==null?Membership.Open:input.Membership.Value,
                DateCreated = DateTime.UtcNow
            };
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            if (!string.IsNullOrEmpty(input.Name))
            {
                var duplicateNames = repo.Get(c => (c.Name == input.Name) && (c.Id != current.Id));
                if (duplicateNames.Any())
                {
                    return new ValidationResult(MessageStrings.GetMessage(MessageStrings.DuplicateCommunityName));
                }
                current.Name = input.Name;
            }
            if (!string.IsNullOrEmpty(input.Description))
            {
                current.Description = input.Description;
            }

            if (input.Membership != null)
            {
                current.Membership = input.Membership.Value;
            }

            processedInput = current;
            return ValidationResult.Success;
        }

    }
}
