namespace Md.LocalStorage.Abstractions.Models;

public class Project
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


    public List<ToDoItem> Items { get; set; } = new();

    public Project()
    {
        
    }
}