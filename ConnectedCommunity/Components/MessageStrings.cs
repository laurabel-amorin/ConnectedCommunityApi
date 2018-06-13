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
        public const string SchoolNameRequired = "SchoolNameRequired";
        public const string SchoolIdRequired = "SchoolIdRequired";

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
