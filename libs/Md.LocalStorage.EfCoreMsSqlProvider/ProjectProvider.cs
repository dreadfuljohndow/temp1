using Md.LocalStorage.Abstractions.Interfaces;
using Md.LocalStorage.Abstractions.Models;

namespace Md.LocalStorage.EfCoreMsSqlProvider;

public class ProjectProvider : BaseProvider, IProjectProvider
{
    public ProjectProvider(string connectionString) : base(connectionString)
    {
    }

    public IReadOnlyCollection<Project> GetProjects()
    {
        List<Project> projects;

        using (var db = GetDbContext())
        {
            projects = db.Projects.ToList();
        }

        return projects;
    }

    public Project GetProjectById(string id)
    {
        throw new NotImplementedException();
    }

    public Project UpdateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Project CreateProject(Project newProject)
    {
        Project project;

        using (var db = GetDbContext())
        {
            db.Projects.Add(newProject);
            db.SaveChanges();
            project = newProject;
        }
        return project;
    }
}