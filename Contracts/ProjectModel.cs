namespace Contracts;

public class ProjectModel
{
    public required ICollection<Project> Projects { get; set; }
}


public class Project
{
    public required string Name { get; set; }
    public required ICollection<Project> Children { get; set; }
}