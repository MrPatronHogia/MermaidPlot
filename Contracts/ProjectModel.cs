namespace Contracts;

public class SolutionModel
{
    public required string SolutionName { get; set; }
    public required ICollection<ProjectItem> Projects { get; set; }
}

public class ProjectItem
{
    public required string ProjectName { get; set; }
    public required ICollection<ChildProject> Children { get; set; }
    public required ICollection<DllReference> References { get; set; }
}
public class ChildProject
{
    public required string ProjectName { get; set; }
}

public class DllReference
{
    public required string ReferenceName { get; set; }
}