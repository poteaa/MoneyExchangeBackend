using System.Collections.Generic;
using MoneyExchange.Model;

namespace MoneyExchange.Data
{
    public interface IRepository
    {
        UserDTO AuthenticateUser(Account account);
        List<CurrencyDTO> GetCurrencies();
        ConversionDTO GetCurrencyExchange(int? currencyId);
    }
}