using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyExchange.Model;

namespace MoneyExchange.Data
{
    public class Repository : IRepository
    {
        IMoneyExchangeContext context = new MoneyExchangeEntities();
        
        public Repository(IMoneyExchangeContext context)
        {
            this.context = context;
        }

        public List<CurrencyDTO> GetCurrencies()
        {
            List<CurrencyDTO> currencies;
            //using (context = new MoneyExchangeEntities())
            //{
                currencies = context.Currencies.AsNoTracking()
                    .Select(c => new CurrencyDTO { Id = c.Id, Acronym = c.Acronym, Name = c.Name }).ToList();
                context.Dispose();
            //}
            return currencies;
        }

        public CurrencyDTO GetCurrency(int id)
        {
            CurrencyDTO currency = context.Currencies.AsNoTracking()
                .Where(cs => cs.Id == id)
                .Select(c => new CurrencyDTO { Id = c.Id, Acronym = c.Acronym, Name = c.Name }).FirstOrDefault();
            context.Dispose();
            return currency;
        }

        public ConversionDTO GetCurrencyExchange(string baseCurrencyAcronym, string targetCurrencyAcronym)
        {
            ConversionDTO currencyExchange;
            //using (context = new MoneyExchangeEntities())
            //{
            var targetCurrency = context
                    .Currencies.AsNoTracking()
                    .Where(c => c.Acronym == targetCurrencyAcronym).FirstOrDefault();
            
            currencyExchange =
                context
                    .Currencies.AsNoTracking()
                    .Where(c => c.Acronym == baseCurrencyAcronym).ToList()
                    .Select(c => new
                    {
                        Acronym = c.Acronym,
                        Conversions = c.Exchanges
                                        .Where(e => e.srcCurrencyId == c.Id && e.trgtCurrencyId == targetCurrency.Id)
                                        .Select(e => new { Key = e.Currency1.Acronym, Value = e.rate })
                    })
                    .AsEnumerable()
                    .Select(c => new ConversionDTO
                    {
                        Base = c.Acronym,
                        Rates = c.Conversions.ToDictionary(k => k.Key, v => v.Value),
                        Date = new DateTime()
                    }).FirstOrDefault();
            //}
            context.Dispose();
            return currencyExchange;
        }
        
        public ConversionDTO GetCurrencyExchanges(string baseCurrencyAcronym)
        {
            ConversionDTO currencyExchange;
            //using (context = new MoneyExchangeEntities())
            //{
            currencyExchange =
                context.Currencies.AsNoTracking()
                    .Where(c => c.Acronym == baseCurrencyAcronym)
                    .Select(c => new
                    {
                        Acronym = c.Acronym,
                        Conversions = c.Exchanges
                                        .Where(e => e.srcCurrencyId == c.Id)
                                        .Select(e => new { Key = e.Currency1.Acronym, Value = e.rate })
                    })
                    .AsEnumerable()
                    .Select(c => new ConversionDTO
                    {
                        Base = c.Acronym,
                        Rates = c.Conversions.ToDictionary(k => k.Key, v => v.Value),
                        Date = new DateTime()
                    }).FirstOrDefault();
            //}
            context.Dispose();
            return currencyExchange;
        }

        public UserDTO AuthenticateUser(Account account)
        {
            UserDTO user;
            //using (context = new MoneyExchangeEntities())
            //{
                user = context.Users.AsNoTracking()
                    .Where(u => u.Username == account.Username && u.Password == account.Password)
                    .Select(u => new UserDTO
                        {
                            Id = u.Id,
                            Name = u.Name,
                            LastName = u.LastName,
                            Username = u.Username
                        }).FirstOrDefault();
            //}
            context.Dispose();
            return user;
        }
    }
}
