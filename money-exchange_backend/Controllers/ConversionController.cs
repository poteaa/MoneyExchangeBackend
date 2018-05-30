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
    public class ConversionController : ApiController
    {
        private readonly Repository repository = new Repository();
        private HttpResponseMessage response = new HttpResponseMessage();

        // GET: CurrencyExchange
        public HttpResponseMessage get(int id)
        {
            if (Request.Headers.Authorization.ToString() != string.Empty)
            {
                ConversionDTO conversion = repository.GetCurrencyExchange(id);
                response = Request.CreateResponse(HttpStatusCode.OK, conversion);
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new Exception("You are not authorized to access this resource"));
            }
            return response;
        }
    }
}
