using System;
using System.Linq;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

Console.WriteLine("Please provide the path to the solution root");
Console.WriteLine();
var path = Console.ReadLine();
// Create an MSBuild workspace
if (!MSBuildLocator.IsRegistered)
    MSBuildLocator.RegisterDefaults();

var workspace = MSBuildWorkspace.Create();

// Open the solution
var solution = await workspace.OpenSolutionAsync(path);

// Iterate over all projects in the solution
foreach (Project project in solution.Projects)
{
    Compilation? compilation = await project.GetCompilationAsync();
    Console.WriteLine($"Project: {project.Name}");
    project.AllProjectReferences.ToList().ForEach(x =>
    {
        Console.WriteLine($"{x}");

        var project_ref = solution.Projects.First(p => p.Id == x.ProjectId);

        Console.WriteLine($"{project_ref.Name}");
    });
}
// workspace.CurrentSolution.GetProject(projectId);