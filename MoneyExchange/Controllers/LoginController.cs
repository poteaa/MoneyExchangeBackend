using MoneyExchange.Data;
using MoneyExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace money_exchange_backend.Controllers
{
    public class LoginController : ApiController
    {
        private readonly Repository repository = new Repository();
        private HttpResponseMessage response = new HttpResponseMessage();

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage NewToken(Account account)
        {
            UserDTO user;
            try
            {
                user = repository.AuthenticateUser(account);
                Authentication auth = null;
                if (user != null)
                {
                    auth = new Authentication { token = Guid.NewGuid().ToString() };
                }
                response = Request.CreateResponse(HttpStatusCode.OK, auth);
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError(ex, true));
            }

            return response;
        }
    }
}
