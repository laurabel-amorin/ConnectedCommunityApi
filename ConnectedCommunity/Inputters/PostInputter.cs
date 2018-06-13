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
    public class PostInputter:Inputter<PostInput, Post, IPostRepository>
    {
        public PostInputter(IPostRepository postRepo, PostInput postInput)
            :base(postRepo, postInput)
        {

        }

        public PostInputter(IPostRepository postRepo, PostInput postInput, Post currentPost)
            :base(postRepo, postInput, currentPost)
        {

        }

        public override async Task<ValidationResult> ValidateNew()
        {
            return ValidationResult.Success;
        }

        public override async Task<ValidationResult> ValidateUpdate()
        {
            return ValidationResult.Success;
        }

    }
}
