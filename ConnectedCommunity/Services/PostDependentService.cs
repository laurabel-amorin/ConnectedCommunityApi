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
    public abstract class PostDependentService:GroupMemberDependentService
    {
        protected readonly IPostRepository postRepo;
        protected Post post;

        public PostDependentService(IPostRepository postRepo, IGroupRepository groupRepo,
            IMemberRepository memberRepo, IGroupMemberRepository groupMemberRepo) : base(groupRepo, memberRepo, groupMemberRepo)
        {
            this.postRepo = postRepo;
        }

        protected async Task<ValidationResult> ValidatePost(int postId)
        {
            var post = await postRepo.FindAsync(postId);
            if (post == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.PostDoesNotExist));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateActivePost(int postId)
        {
            var validatePostResult = await ValidatePost(postId);
            if (validatePostResult != ValidationResult.Success)
            {
                return validatePostResult;
            }
            if (post.DateArchived!=null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.PostArchived));
            }
            return ValidationResult.Success;
        }

    }
}
