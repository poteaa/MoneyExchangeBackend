using System.Collections.Generic;
using MoneyExchange.Model;

namespace MoneyExchange.Data
{
    public interface IRepository
    {
        /// <summary>
        /// Authenticates the user in the application
        /// </summary>
        /// <param name="account">The data of the user to be logged.</param>
        /// <returns></returns>
        UserDTO AuthenticateUser(Account account);

        /// <summary>
        /// Get the currencies.
        /// </summary>
        /// <returns>List of currencies.</returns>
        List<CurrencyDTO> GetCurrencies();

        /// <summary>
        /// Gets an specific currency
        /// </summary>
        /// <param name="id">Id of the currency</param>
        /// <returns>Currency</returns>
        CurrencyDTO GetCurrency(int id);

        /// <summary>
        /// Gets the equivalent from one currency to another.
        /// </summary>
        /// <param name="baseCurrencyAcronym">The acronym of the get the equivalent.</param>
        /// <param name="targetCurrencyAcronym">The acronym of the resulting currency.</param>
        /// <returns>The equivalence.</returns>
        ConversionDTO GetCurrencyExchange(string baseCurrencyAcronym, string targetCurrencyAcronym);

        /// <summary>
        /// Gets the list of equivalences for one currency.
        /// </summary>
        /// <param name="baseCurrencyAcronym">The acronym of the get the equivalent.</param>
        /// <returns>The list of equivalences.</returns>
        ConversionDTO GetCurrencyExchanges(string baseCurrencyAcronym);
    }
}