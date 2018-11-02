using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace money_exchange_backend.Auth
{
    public class CustomAuthorize : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(
               System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            var token = actionContext.Request.Headers.Authorization;
            if (token != null)
            {
                string authenticationToken = Convert.ToString(token);
                if (!TokenStorage.GetInstance().ValidateToken(authenticationToken))
                {
                    HttpContext.Current.Response.AddHeader("Authorization", authenticationToken);
                    HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                    return;
                }

                HttpContext.Current.Response.AddHeader("Authorization", authenticationToken);
                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                return;
            }
            actionContext.Response =
              actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            actionContext.Response.ReasonPhrase = "Please provide valid authorization";
        }
    }
}