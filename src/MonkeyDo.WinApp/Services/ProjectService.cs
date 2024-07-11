using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Md.LocalStorage.EfCoreMsSqlProvider;
using MonkeyDo.WinApp.DataModel;

namespace MonkeyDo.WinApp.Services
{
    public class ProjectService
    {
        private readonly string _connectionString = "Server=(local);Database=MonkeyDoApp_dev;User Id=admin;Password=admin;Trust Server Certificate=true";

        public ProjectService()
        {
        }


        private ProjectProvider GetLocalItemStorage()
        {
            var localStorage = new ProjectProvider(_connectionString);
            return localStorage;
        }

        public IEnumerable<ProjectModel> GetProjects()
        {

            var localStorage = GetLocalItemStorage();

            var items = localStorage.GetProjects();

            var itemViews = items.Select(i => new ProjectModel(this)
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description
            });

            return itemViews;
        }

        public ProjectModel AddNewProject(ProjectModel item)
        {
            var localStorage = GetLocalItemStorage();

            var storageItem = new Md.LocalStorage.Abstractions.Models.Project
            {
                Name = item.Name,
                Description = item.Description,
                Id = Guid.NewGuid().ToString()
            };

            localStorage.CreateProject(storageItem);

            item.Id = storageItem.Id;
            item.Name = storageItem.Name;
            item.Description = storageItem.Description;
            return item;
        }

        public ProjectModel GetToDoItemById(string id)
        {
            var localStorage = GetLocalItemStorage();

            var item = localStorage.GetProjectById(id);
            return new ProjectModel(this)
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
        }

        public ProjectModel UpdateToDoItem(ProjectModel item)
        {
            var localStorage = GetLocalItemStorage();

            var savedItem = localStorage.GetProjectById(item.Id);

            savedItem.Name = item.Name;
            savedItem.Description = item.Description;

            savedItem = localStorage.UpdateProject(savedItem);

            return new ProjectModel(this)
            {
                Id = savedItem.Id,
                Name = savedItem.Name,
                Description = savedItem.Description
            };
        }
    }
}
