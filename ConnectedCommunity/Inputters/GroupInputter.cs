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
        private readonly GroupInput groupInput;
        private readonly int groupId;
        private Group group;

        public GroupInputter(GroupInput groupInput):base(groupInput)
        {

        }

        public GroupInputter(GroupInput groupInput, int groupId) : base(groupInput, groupId)
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
