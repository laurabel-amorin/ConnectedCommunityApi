using ConnectedCommunity.Model;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class GroupInputter:Inputter<GroupInput, Group>
    {
        public GroupInputter(GroupInput groupInput):base(groupInput)
        {

        }

        public GroupInputter(GroupInput groupInput, Group currentGroup) : base(groupInput, currentGroup)
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
