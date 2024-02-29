
using Application;

Console.WriteLine("Please provide the path to the json");
Console.WriteLine();

var path = Console.ReadLine();


var json = File.ReadAllText(path);

// var result = await new OpenAI().Chat(prompt, userPrompt.Replace(" ", ""));