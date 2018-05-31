using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using money_exchange_backend.Controllers;
using MoneyExchange.Data;
using MoneyExchange.Model;

namespace money_exchange_backend.Tests
{
    [TestClass]
    public class TestConversionController
    {
        [TestMethod]
        public void GetConversion_ShouldReturnConversionsForACurrency()
        {
            //TODO: complete the unit test sending the token
            //var context = new MoneyExchangeAppContext();
            //var repository = new Repository(context);
            //context.Currencies.Add(new Currency { Id = 1, Acronym = "USD", Name = "USA Dollar" });
            //context.Currencies.Add(new Currency { Id = 2, Acronym = "EUR", Name = "Euro" });
            //context.Exchanges.Add(new Exchange { Id = 1, srcCurrencyId = 1, trgtCurrencyId = 2});
            //var controller = new ConversionController(repository);
            //var result = controller.get(1) as ConversionDTO;
            //Assert.IsNotNull(result);
        }
    }
}
