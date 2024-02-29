
using Application;
Console.WriteLine("Please provide the path to the json");
Console.WriteLine();

var path = Console.ReadLine();
Console.WriteLine("Please provide the graph to create");
Console.WriteLine();
var diagram_graph = Console.ReadLine();
Console.WriteLine("WORKING VERY HARD");
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
File.WriteAllText($@"C:\Repos\{diagram_graph}.md", result);
