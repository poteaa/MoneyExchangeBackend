using money_exchange_backend.Auth;
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
    public class ExchangeController : ApiController
    {
        private readonly IRepository repository;
        private IHttpActionResult response = null;
        public ExchangeController()
        {
            this.repository = new Repository(new MoneyExchangeEntities());
        }

        public ExchangeController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: CurrencyExchange
        [CustomAuthorize]
        [ResponseType(typeof(ConversionDTO))]
        [HttpGet, Route("api/exchange/{base?}/{symbols?}")]
        public IHttpActionResult GetRate([FromUri(Name = "base")] string baseCurrencyAcronym,
            [FromUri(Name = "symbols")] string targetCurrencyAcronym)
        {
            ConversionDTO conversion;
            try
            {
                conversion = repository.GetCurrencyExchange(baseCurrencyAcronym, targetCurrencyAcronym);
                if (conversion == null)
                {
                    response = NotFound();
                }
                else
                {
                    response = Ok(conversion);
                }
            }
            catch (Exception ex)
            {
                // Write the excption to a log
                response = InternalServerError();
            }

            return response;
        }

        //GET: CurrencyExchange
        [ResponseType(typeof(ConversionDTO))]
        [HttpGet, Route("api/exchange/rates/{base?}")]
        public IHttpActionResult GetAllRates([FromUri(Name = "base")] string baseCurrencyAcronym)
        {
            ConversionDTO conversion;
            try
            {
                conversion = repository.GetCurrencyExchanges(baseCurrencyAcronym);
                if (conversion == null)
                {
                    response = NotFound();
                }
                else
                {
                    response = Ok(conversion);
                }
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
