using System;
using System.Collections.Generic;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.ViewModels.TreeView;

namespace MonkeyDo.WinApp.ViewModels.DesignData;

public static class DesignData
{
    public static TreeViewViewModel ExampleToDoListViewModel { get; } = new TreeViewViewModel(new List<ToDoItemModel>()
    {
        new ToDoItemModel(null)
        {
            AddedDateTime = DateTime.MinValue,
            Description = "description item",
            IdeaName = "idea name asdlkalskdjasd",
            IsChecked = true,
            IsRed = true,
            ProjectName = "project name",
            ProjectId = "projectId"
        }
    }, new List<ProjectModel>
    {
        new ProjectModel(service : null)
        {
            Id = "iddasdasd",
            Name = "projectName1",
            Description = "project1Description"
        }
    });

    public static ConfigureTaskExternalDataSourceViewModel ExampleConfigureTaskExternalDataSourceViewModel { get; } =
        new ConfigureTaskExternalDataSourceViewModel(new List<ConfigureTaskExternalDataSourceItemViewModel>()
        {
            new ConfigureTaskExternalDataSourceItemViewModel
            {
                ProjectName = "Project23423",
                ConfigType = "AzureDevOps",
                OrganizationName = "Denis_Ladutsko",
                PAT = "bsvsddddddddddfffffffffffffffffffffffffr",
                SourceName = "Project23423-Azure"
            },
            new ConfigureTaskExternalDataSourceItemViewModel
            {
                ProjectName = "Project123",
                ConfigType = "AzureDevOps",
                OrganizationName = "Denis_Ladutsko",
                PAT = "bsvsddddddddddfffffffffffffffffffffffffr",
                SourceName = "Project123-Azure"
            }
        });
}