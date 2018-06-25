using ConnectedCommunity.Components;
using ConnectedCommunity.Helpers;
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

        public override ValidationResult ValidateNew()
        {
            if (input.GroupId==0)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.InvalidGroupId));
            }

            if (input.MemberId == 0)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.InvalidMemberId));
            }

            if (string.IsNullOrEmpty(input.Content))
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.PostContentEmpty));
            }

            string heading = input.Heading;
            if (string.IsNullOrEmpty(heading))
            {
                heading = StringHelper.GetContractedText(input.Content);
            }

            processedInput = new Post
            {
                GroupId=input.GroupId,
                MemberId=input.MemberId,
                GroupMemberId=input.GroupMemberId,
                Content=input.Content,
                Title=heading,
                DateCreated=DateTime.UtcNow
            };
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            if (!string.IsNullOrEmpty(input.Content))
            {
                current.Content = input.Content;
                current.DateModified = DateTime.UtcNow;
            }

            if (!string.IsNullOrEmpty(input.Heading))
            {
                current.Title = input.Heading;
                current.DateModified = DateTime.UtcNow;
            }

            processedInput = current;
            return ValidationResult.Success;
        }

    }
}
