using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlTools.MssqlFluentSqlWrapper;

namespace Md.LocalStorage.MsSqlProvider
{
    public class BaseProvider
    {
        private string _connectionString { get; init; }

        public BaseProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected FluentSqlCommand CreateSqlCommand()
        {
            var client = new FluentSqlCommand(_connectionString);
            return client;
        }
    }
}