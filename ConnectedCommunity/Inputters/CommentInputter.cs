using ConnectedCommunity.Model;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class CommentInputter:Inputter<CommentInput, Comment>
    {
        public CommentInputter(CommentInput commentInput):base(commentInput)
        {

        }

        public CommentInputter(CommentInput commentInput, Comment currentComment) : base(commentInput, currentComment)
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
