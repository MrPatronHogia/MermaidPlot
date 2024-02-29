using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace Application
{
  public class OpenAI
  {
    public async Task<string> Chat(string systemPrompt, string userPrompt)
    {
      OpenAIClient client = new OpenAIClient(
        new Uri(""),
        new AzureKeyCredential(""));

      Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
      "Gpt4",
      new ChatCompletionsOptions()
      {
        Messages =
        {
      new ChatMessage(ChatRole.System,systemPrompt ),
      new ChatMessage(ChatRole.User,userPrompt),
        },
        Temperature = (float)0.7,
        MaxTokens = 5000,
        NucleusSamplingFactor = (float)0.95,
        FrequencyPenalty = 0,
        PresencePenalty = 0,
      });

      var choiceFirst = responseWithoutStream.Value.Choices.First();

      return choiceFirst.Message.Content;
    }
  }
}