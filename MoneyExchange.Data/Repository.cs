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
        public ConversionDTO GetCurrencyExchange(int? currencyId)
        {
            ConversionDTO currencyExchange;
            //using (context = new MoneyExchangeEntities())
            //{
                currencyExchange = 
                    context.Currencies.AsNoTracking()
                        .Where(c => c.Id == currencyId)
                        .Select(c => new
                        {
                            Acronym = c.Acronym,
                            Conversions = c.Exchanges
                                            .Where(e => e.srcCurrencyId == currencyId)
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
            if (user == null)
            {
                throw new Exception("User or password incorrect");
            }
            return user;
        }
    }
}
