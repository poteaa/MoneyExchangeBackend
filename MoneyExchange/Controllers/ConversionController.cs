using MoneyExchange.Data;
using MoneyExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace money_exchange_backend.Controllers
{
    public class ConversionController : ApiController
    {
        private readonly IRepository repository;
        public ConversionController()
        {
            this.repository = new Repository(new MoneyExchangeEntities());
        }

        public ConversionController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: CurrencyExchange
        [ResponseType(typeof(ConversionDTO))]
        public IHttpActionResult get(int id)
        {
            if (Request.Headers.Authorization.ToString() != string.Empty)
            {
                ConversionDTO conversion = repository.GetCurrencyExchange(id);
                return Ok(conversion);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
