using System;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Solution.Component.Base.DataBase.Provider
{
    public abstract class AbstractConnectionFactory : IConnectionFactory
    {

        protected IConfiguration _configuration;

        public AbstractConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract DbConnection GetConnection(string connectionString);
    }

}