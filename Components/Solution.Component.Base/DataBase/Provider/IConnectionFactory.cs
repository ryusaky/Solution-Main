using System;
using System.Data.Common;

namespace Solution.Component.Base.DataBase.Provider
{
    public interface IConnectionFactory
    {
        DbConnection GetConnection(string connectionString);
    }
}

