using System;
using System.Linq;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

// Create an MSBuild workspace
if (!MSBuildLocator.IsRegistered)
    MSBuildLocator.RegisterDefaults();

var workspace = MSBuildWorkspace.Create();

// Open the solution
var solutionPath = "../../../../mermaid_plot.sln";
var solution = await workspace.OpenSolutionAsync(solutionPath);

// Iterate over all projects in the solution
foreach (Project project in solution.Projects)
{
    Console.WriteLine($"Project: {project.Name}");
    project.AllProjectReferences.ToList().ForEach(x =>
    {
        Console.WriteLine($"{x}");

        var project_ref = solution.Projects.First(p => p.Id == x.ProjectId);

        Console.WriteLine($"{project_ref.Name}");
    });
}