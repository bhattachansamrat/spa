using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using Spa.Web.Infrastructure.Extension;
using System.Web;

namespace Spa.Web.Infrastructure.MessageHandler
{
    public class SpaMessageHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<string> requestHeader;
                // get request Header
                if (!request.Headers.TryGetValues("Authorization", out requestHeader))
                {
                    return base.SendAsync(request, cancellationToken);
                }

                var tokens = requestHeader.FirstOrDefault();
                if (null == tokens)
                {
                    return DefaultMessageAsync(HttpStatusCode.Forbidden);
                }
                tokens = tokens.Replace("Basic", "");
                if(string.IsNullOrEmpty(tokens))
                {
                    return DefaultMessageAsync(HttpStatusCode.Forbidden);
                }
                var data = Convert.FromBase64String(tokens);
                var decodedString = Encoding.UTF8.GetString(data);
                var tokenValues = decodedString.Split(':');
                var memberShipService = request.GetMemberShipService();

                var membershipContext = memberShipService.ValidateUser(tokenValues[0], tokenValues[1]);
                if (null == membershipContext.User)
                {
                    return DefaultMessageAsync(HttpStatusCode.Unauthorized);
                }

                // user is authenticated
                Thread.CurrentPrincipal = membershipContext.Principal;
                HttpContext.Current.User = membershipContext.Principal;

                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return DefaultMessageAsync(HttpStatusCode.Forbidden);
            }
        }

        private Task<HttpResponseMessage> DefaultMessageAsync(HttpStatusCode code)
        {
            var responseMsg = new HttpResponseMessage(code);
            var tsc = new TaskCompletionSource<HttpResponseMessage>(responseMsg);
            return tsc.Task;
        }
    }
}