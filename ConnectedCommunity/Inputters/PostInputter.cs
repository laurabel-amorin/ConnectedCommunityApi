using ConnectedCommunity.Model;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class PostInputter:Inputter<PostInput, Post>
    {
        private readonly PostInput postInput;
        private readonly int postId;
        private Post post;

        public PostInputter(PostInput postInput):base(postInput)
        {

        }

        public PostInputter(PostInput postInput, int postId) : base(postInput, postId)
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
