using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace money_exchange_backend.Auth
{
    public class TokenStorage
    {
        private static TokenStorage instance;
        private static List<string> tokens = new List<string>();
        private TokenStorage() { }

        public static TokenStorage GetInstance()
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new TokenStorage();
                }
            }
            return instance;
        }

        public void SaveToken(string token)
        {
            TokenStorage.tokens.Add(token);
        }

        public void RemoveToken(string token)
        {
            TokenStorage.tokens.Remove(token);
        }

        public Boolean ValidateToken(string token)
        {
            return TokenStorage.tokens.FindIndex(t => t == token) > -1;
        }
    }
}