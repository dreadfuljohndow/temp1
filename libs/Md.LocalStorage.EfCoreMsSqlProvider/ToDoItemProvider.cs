using Md.LocalStorage.Abstractions.Interfaces;
using Md.LocalStorage.Abstractions.Models;

namespace Md.LocalStorage.EfCoreMsSqlProvider
{
    public class ToDoItemProvider : BaseProvider, IToDoItemsProvider
    {
        public ToDoItemProvider(string connectionString):base (connectionString)
        { }

        public IList<ToDoItem> GetToDoItems()
        {
            IList<ToDoItem> items;

            using (var context = GetDbContext())
            {
                items = context.ToDoItems.ToList();
            }

            return items;
        }

        public ToDoItem GetToDoItem(string id)
        {
            ToDoItem? item = null;
            using (var context = GetDbContext())
            {
                item = context.ToDoItems.Where(i => i.Id == id).FirstOrDefault();
            }

            return item;
        }

        public ToDoItem AddNewToDoItem(ToDoItem newItem)
        {
            ToDoItem? item = null;
            using (var context = GetDbContext())
            {
                context.ToDoItems.Add(newItem);
                context.SaveChanges();
                item = newItem;
            }

            return item;
        }

        public ToDoItem UpdateToDoItem(ToDoItem updatedItem)
        {
            ToDoItem? item = null;
            using (var context = GetDbContext())
            {
                context.ToDoItems.Update(updatedItem);
                context.SaveChanges();
                item = updatedItem;
            }
            return item;
        }
    }
}
