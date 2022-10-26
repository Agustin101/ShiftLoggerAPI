using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using UI.Models;

namespace UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UserInput userInput = new();
            await userInput.GetInput();

        }
    }
}