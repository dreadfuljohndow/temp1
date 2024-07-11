using System.Collections;
using Md.LocalStorage.Abstractions.Models;

namespace Md.LocalStorage.Abstractions.Interfaces
{
    public interface IToDoItemsProvider
    {
        ToDoItem GetToDoItem(string id);
        ToDoItem AddNewToDoItem(ToDoItem newItem);
        IList<ToDoItem> GetToDoItems();
        ToDoItem UpdateToDoItem(ToDoItem updatedItem);
    }
}