using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Md.LocalStorage.Abstractions.Interfaces;
using Md.LocalStorage.Abstractions.Models;

namespace Md.LocalStorage.MsSqlProvider
{
    public class ToDoItemProvider : BaseProvider, IToDoItemsProvider
    {
        public ToDoItemProvider(string connectionString):base(connectionString)
        { }

        public ToDoItem GetToDoItem(string id)
        {
            var client = CreateSqlCommand();

            var item = client.StoredProc("getToDoItemsById").ExecReadItem<ToDoItem>(record => new ToDoItem
            {
                Id = record.GetString(record.GetOrdinal("id")),
                Title = record.GetString(record.GetOrdinal("title")),
                CreatedDateTime = record.GetDateTime(record.GetOrdinal("created_datetime"))
            });

            return item;
        }

        public ToDoItem AddNewToDoItem(ToDoItem newItem)
        {
            throw new NotImplementedException();
        }

        public IList<ToDoItem> GetToDoItems()
        {
            throw new NotImplementedException();
        }

        public ToDoItem UpdateToDoItem(ToDoItem updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}