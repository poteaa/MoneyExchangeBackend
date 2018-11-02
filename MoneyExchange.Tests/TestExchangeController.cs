using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using money_exchange_backend.Controllers;
using MoneyExchange.Data;
using MoneyExchange.Model;

namespace money_exchange_backend.Tests
{
    [TestClass]
    public class TestExchangeController
    {
        private MoneyExchangeAppContext context = new MoneyExchangeAppContext();
        private ExchangeController controller;

        [TestInitialize]
        public void Initialize()
        {
            var repository = new Repository(context);
            var currency = new Currency { Id = 1, Acronym = "USD", Name = "USA Dollar" };
            var currency1 = new Currency { Id = 2, Acronym = "EUR", Name = "Euro" };
            context.Currencies.Add(currency);
            context.Currencies.Add(currency1);
            var exchange = new Exchange
            {
                Id = 1,
                srcCurrencyId = 1,
                Currency = currency,
                trgtCurrencyId = 2,
                Currency1 = currency1,
                rate = 0.27
            };
            currency.Exchanges.Add(exchange);
            currency1.Exchanges.Add(exchange);
            context.Exchanges.Add(exchange);

            controller = new ExchangeController(repository);
        }

        [TestMethod]
        public void GetConversion_ShouldReturnConversionsForACurrencyToAnother()
        {
            // Arrange


            // Act
            IHttpActionResult actionResult = controller.GetRate("USD", "EUR");

            // Assert
            var negResult = actionResult as OkNegotiatedContentResult<MoneyExchange.Model.ConversionDTO>;
            Assert.IsNotNull(negResult);
            Assert.IsNotNull(negResult.Content);
        }

        [TestMethod]
        public void GetConversion_ShouldReturnAllConversionsForACurrency()
        {
            // Arrange
            

            // Act
            IHttpActionResult actionResult = controller.GetAllRates("USD");

            // Assert
            var negResult = actionResult as OkNegotiatedContentResult<MoneyExchange.Model.ConversionDTO>;
            Assert.IsNotNull(negResult);
            Assert.IsNotNull(negResult.Content);
        }

        [TestMethod]
        public void GetConversion_ShouldReturn_NotFound()
        {
            // Arrange


            // Act
            IHttpActionResult actionResult = controller.GetAllRates("USP");

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
