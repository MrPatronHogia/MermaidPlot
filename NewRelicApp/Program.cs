using Application;

while (true)
{
    var path = "";
    var diagram_graph = "";

    int starMenue = ShowMenu.Menu("New relic graph", new[]
    {
                    "Select path to json",

                    "Exit"
                });
    if (starMenue == 0)
    {
        Console.Clear();
        Console.WriteLine("Please provide the path to the json");
        Console.WriteLine();
        path = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Please provide the graph to create");
        Console.WriteLine();
        int selectGraph = ShowMenu.Menu("Select graph", new[]
    {
                    "Graph",
                    "Class",

                    "Exit"
                });
        if (selectGraph == 0)
        {
            diagram_graph = "graph";
        }
        if (selectGraph == 1)
        {
            diagram_graph = "class";
        }
        else
        {
        }
    }
    else
    {
        Environment.Exit(0);
    }

    Console.Clear();

    Console.WriteLine($"Selected diagram {diagram_graph}");
    Console.WriteLine();
    Console.WriteLine("AI is working very hard!");
    Console.WriteLine();
    var json = File.ReadAllText(path);

    var prompt = @$"
Input: A JSON file representing newRelic Data, It contains logs from different services.
Your job is to connect the different dependencies that all the services have with one another.
The graph that you will present will be a mermaid diagram that shows the dependencies between the services with the name of the service calling,
the http method and the service that is recieving the request.
Make sure to include wrap all the elements with the syntax example[Service1]-->[Service2] and make sure to include the http method in the middle of the two services.]
Output: {diagram_graph} visualizing the relationships between the projects in the solution using mermaid diagrams.
Additional Notes:
The diagram should use appropriate notation to represent the relationships between projects (e.g., directed arrows for dependencies).
Consider including project names and other relevant information within the  shapes.
You are going to use mermaid diagram to generate the output.
The output should always start with ``` mermaid and end with ```
For example: ``` mermaid {{Content here}} ```
";
    var result = await new OpenAI().Chat(prompt, json);

    Console.WriteLine("Finished");
    Console.WriteLine();

    Console.WriteLine("Provide the path to save the file");
    var filePath = Console.ReadLine();
    File.WriteAllText($@"{filePath}\new.relic.{diagram_graph}.md", result);

    Environment.Exit(0);
}