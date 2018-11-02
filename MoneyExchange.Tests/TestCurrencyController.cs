using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using money_exchange_backend.Controllers;
using MoneyExchange.Data;
using MoneyExchange.Model;

namespace money_exchange_backend.Tests
{
    [TestClass]
    public class TestCurrencyController
    {
        private MoneyExchangeAppContext context = new MoneyExchangeAppContext();
        private CurrencyController controller = null;

        [TestInitialize]
        public void Initialize()
        {
            var repository = new Repository(context);
            context.Currencies.Add(new Currency { Id = 1, Acronym = "USD", Name = "USA Dollar" });
            context.Currencies.Add(new Currency { Id = 2, Acronym = "EUR", Name = "Euro" });
            controller = new CurrencyController(repository);
        }

        [TestMethod]
        public void GetCurrencies_ShoulReturnAllCurrencies()
        {
            // Arrange
            var count = context.Currencies.Local.Count;
            
            // Act
            IHttpActionResult actionResult = controller.GetCurrencies();
            var negResult = actionResult as OkNegotiatedContentResult<List<CurrencyDTO>>;

            // Assert
            Assert.IsNotNull(negResult);
            Assert.IsNotNull(negResult.Content);
            Assert.AreEqual(count, negResult.Content.Count);
        }

        [TestMethod]
        public void GetCurrency_ShoulReturnAnSpecificCurrency()
        {
            var currency = context.Currencies.Local[0];
            var count = context.Currencies.Local.Count;
            IHttpActionResult actionResult = controller.GetCurrency(currency.Id);
            var negResult = actionResult as OkNegotiatedContentResult<CurrencyDTO>;
            Assert.IsNotNull(negResult);
            Assert.IsNotNull(negResult.Content);
            Assert.AreEqual(currency.Name, negResult.Content.Name);
        }
    }
}
