using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using money_exchange_backend.Controllers;
using MoneyExchange.Data;
using MoneyExchange.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private MoneyExchangeEntities _context;
        
        [TestInitialize]
        public void Initialize()
        {
            _context = new MoneyExchangeEntities(Effort.DbConnectionFactory.CreateTransient());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetById_throwException_whenIdDoesnExists()
        {
            var repository = new Repository(_context);
            _context.Currencies.Add(new Currency { Id = 1, Acronym = "USD", Name = "USA Dollar" });
            _context.Currencies.Add(new Currency { Id = 2, Acronym = "EUR", Name = "Euro" });
            var controller = new CurrencyController(repository);
            var result = controller.GetCurrencies() as List<CurrencyDTO>;
            Assert.IsNotNull(result);
        }
    }
}
