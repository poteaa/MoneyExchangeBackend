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
    public class CurrencyController : ApiController
    {
        private readonly IRepository repository;
        public CurrencyController()
        {
            this.repository = new Repository(new MoneyExchangeEntities());
        }
        public CurrencyController(IRepository repository)
        {
            this.repository = repository;
        }

        [ResponseType(typeof(List<CurrencyDTO>))]
        public IHttpActionResult GetCurrencies()
        {
            List<CurrencyDTO> currencies = repository.GetCurrencies();
            return Ok(currencies);
        }

        [ResponseType(typeof(CurrencyDTO))]
        public IHttpActionResult GetCurrency(int id)
        {
            CurrencyDTO currency = repository.GetCurrency(id);
            return Ok(currency);
        }
    }
}
