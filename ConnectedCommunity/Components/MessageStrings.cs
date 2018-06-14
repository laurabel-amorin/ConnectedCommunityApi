using Microsoft.AspNetCore.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectedCommunity.Components
{
    public static class MessageStrings
    {
        public const string CommunitySchoolNameRequired = "CommunitySchoolNameRequired";
        public const string CommunitySchoolIdRequired = "CommunitySchoolIdRequired";
        public const string DuplicateCommunityName = "DuplicateCommunityName";
        public const string CommunityDoesNotExist = "CommunityDoesNotExist";
        public const string CommunityInactive = "CommunityInactive";

        public const string GroupNameRequired = "GroupNameRequired";
        public const string DuplicateGroupName = "DuplicateGroupName";
        public const string GroupDoesNotExist = "GroupDoesNotExist";
        public const string DefaultGroupMembership = "DefaultGroupMembership";

        public const string MemberDoesNotExist = "MemberDoesNotExist";
        public const string MemberInactive = "MemberInactive";
        public const string InvalidMemberUserId = "InvalidMemberUserId";

        public const string GroupMemberDoesNotExist = "GroupMemberDoesNotExist";
        public const string GroupMemberInactive = "GroupMemberInactive";
        public const string InvalidMemberId = "InvalidMemberId";
        public const string InvalidGroupId = "InvalidGroupId";
        public const string CannotUpdateGroupMember = "CannotUpdateGroupMember";

        public const string PostDoesNotExist = "PostDoesNotExist";
        public const string PostArchived = "PostArchived";
        public const string PostContentEmpty = "PostContentEmpty";
        public const string CannotUpdateMedia = "CannotUpdateMedia";

        public const string CommentDoesNotExist = "CommentDoesNotExist";
        public const string CommentContentEmpty = "CommentContentEmpty";


        public static string GetMessage(string key)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(key))
            {
                return message;
            }

            log4net.ILog logManager = log4net.LogManager
               .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                var hostingEnvironment = new HostingEnvironment();
                string rootPath = hostingEnvironment.ContentRootPath;
                var json = File.ReadAllText(rootPath + "\\MessageStrings.json");
                var jObject = (JObject)JsonConvert.DeserializeObject(json);
                message = jObject[key]?.ToString();
            }
            catch(IOException io)
            {
                logManager.Error(io.Message);
            }
            catch (NotSupportedException ns)
            {
                logManager.Error(ns.Message);
            }
            catch(UnauthorizedAccessException un)
            {
                logManager.Error(un.Message);
            }
            catch(JsonSerializationException js)
            {
                logManager.Error(js.Message);
            }
            return message;
        }
    }
}
