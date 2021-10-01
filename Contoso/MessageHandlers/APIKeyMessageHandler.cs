using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Contoso.MessageHandlers
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        private const string APIKey = "261201";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken token)
        {
            bool validKey = false;

            IEnumerable<string> requestHeaders;

            bool checkApiKeyExists = message.Headers.TryGetValues("APIKey", out requestHeaders);

            if(checkApiKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKey))
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                return message.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            var response = await base.SendAsync(message, token);

            return response;
        }
    }
}