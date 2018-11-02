using money_exchange_backend.Auth;
using MoneyExchange.Data;
using MoneyExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace money_exchange_backend.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IRepository repository;
        private IHttpActionResult response = null;

        public LoginController()
        {
            this.repository = new Repository(new MoneyExchangeEntities());
        }

        public LoginController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IHttpActionResult> NewToken(Account account)
        {
            UserDTO user;
            try
            {
                user = repository.AuthenticateUser(account);
                Authentication auth = null;
                if (user == null)
                {
                    response = NotFound();
                }
                else
                {
                    var token = await TokenGenerator.Generate();
                    auth = new Authentication { token = token, user = user };
                    TokenStorage.GetInstance().SaveToken(auth.token);
                    response = Ok(auth);
                }
            }
            catch(Exception ex)
            {
                // Write the excption to a log
                response = InternalServerError();
            }

            return response;
        }

        [HttpPost]
        [Route("api/logout")]
        public IHttpActionResult Logout(Authentication auth)
        {
            try
            {
                money_exchange_backend.Auth.TokenStorage.GetInstance().RemoveToken(auth.token);
                response = Ok();
            }
            catch (Exception ex)
            {
                // Write the excption to a log
                response = InternalServerError();
            }

            return response;
        }
    }
}
