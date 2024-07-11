using Md.LocalStorage.Abstractions.Models;

namespace Md.LocalStorage.Abstractions.Interfaces;

public interface IProjectProvider
{
    IReadOnlyCollection<Project> GetProjects();
    Project GetProjectById(string id);
    Project UpdateProject(Project project);
    Project CreateProject(Project project);
}