using System;
using System.Collections.Generic;
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
        [TestMethod]
        public void GetCurrencies_ShoulReturnAllCurrencies()
        {
            var context = new MoneyExchangeAppContext();
            var repository = new Repository(context);
            context.Currencies.Add(new Currency { Id = 1, Acronym = "USD", Name = "USA Dollar" });
            context.Currencies.Add(new Currency { Id = 2, Acronym = "EUR", Name = "Euro" });
            var controller = new CurrencyController(repository);
            var result = controller.GetCurrencies() as List<CurrencyDTO>;
            Assert.IsNotNull(result);
        }
    }
}
