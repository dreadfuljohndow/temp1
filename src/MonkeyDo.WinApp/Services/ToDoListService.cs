using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Md.LocalStorage.EfCoreMsSqlProvider;
using MonkeyDo.WinApp.DataModel;

namespace MonkeyDo.WinApp.Services
{
    public class ToDoListService
    {
        private readonly string _connectionString = "Server=(local);Database=MonkeyDoApp_dev;User Id=admin;Password=admin;Trust Server Certificate=true";

        private ToDoItemProvider GetLocalItemStorage()
        {
            var localStorage = new ToDoItemProvider(_connectionString);
            return localStorage;
        }

        public IEnumerable<ToDoItemModel> GetItems()
        {

            var localStorage = GetLocalItemStorage();

            var items = localStorage.GetToDoItems();

            var itemViews = items.Select(i => new ToDoItemModel(this)
            {
                Id = i.Id,
                AddedDateTime = i.CreatedDateTime,
                Description = i.Title,
                IsChecked = i.IsCompleted,
                ProjectId = i.ProjectId
            });

            return itemViews;
        }

        public ToDoItemModel AddNewItem(ToDoItemModel item)
        {
            var localStorage = GetLocalItemStorage();

            var storageItem = new Md.LocalStorage.Abstractions.Models.ToDoItem
            {
                CreatedDateTime = DateTime.Now,
                Title = item.Description,
                Id = Guid.NewGuid().ToString(),
                ProjectId = item.ProjectId
            };

            localStorage.AddNewToDoItem(storageItem);

            item.AddedDateTime = storageItem.CreatedDateTime;
            item.IsChecked = storageItem.IsCompleted;
            item.Id = storageItem.Id;
            item.ProjectId = storageItem.ProjectId;
            return item;
        }

        public ToDoItemModel GetToDoItemById(string id)
        {
            var localStorage = GetLocalItemStorage();

            var item = localStorage.GetToDoItem(id);
            return new ToDoItemModel(this)
            {
                Id = item.Id,
                AddedDateTime = item.CreatedDateTime,
                Description = item.Title,
                IsChecked = item.IsCompleted,
                ProjectId = item.ProjectId
            };
        }

        public List<ToDoItemModel> GetToDoItemsAssignedToProject(string projectId)
        {
            var localStorage = GetLocalItemStorage();

            var allItems = localStorage.GetToDoItems();

            var items = allItems.Where(i => i.ProjectId == projectId).Select(

                item => new ToDoItemModel(this)
                {
                    Id = item.Id,
                    AddedDateTime = item.CreatedDateTime,
                    Description = item.Title,
                    IsChecked = item.IsCompleted,
                    ProjectId = item.ProjectId
                }
            ).ToList();
            return items;
        }

        public List<ToDoItemModel> GetToDoItemsWithNoProject()
        {
            var localStorage = GetLocalItemStorage();

            var allItems = localStorage.GetToDoItems();

            var items = allItems.Where(i => string.IsNullOrWhiteSpace(i.ProjectId)).Select(

                item => new ToDoItemModel(this)
                {
                    Id = item.Id,
                    AddedDateTime = item.CreatedDateTime,
                    Description = item.Title,
                    IsChecked = item.IsCompleted,
                    ProjectId = item.ProjectId
                }
            ).ToList();
            return items;
        }


        public ToDoItemModel UpdateToDoItem(ToDoItemModel item)
        {
            var localStorage = GetLocalItemStorage();

            var savedItem = localStorage.GetToDoItem(item.Id);

            savedItem.IsCompleted = item.IsChecked;
            savedItem.Title = item.Description;
            savedItem.ProjectId = item.ProjectId;

            savedItem = localStorage.UpdateToDoItem(savedItem);

            return new ToDoItemModel(this)
            {
                Id = savedItem.Id,
                AddedDateTime = savedItem.CreatedDateTime,
                Description = savedItem.Title,
                IsChecked = savedItem.IsCompleted,
                ProjectId = savedItem.ProjectId
            };
        }
    }
}
