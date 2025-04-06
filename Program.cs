using Azure;
using Azure.AI.OpenAI;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string apiKey = configuration["OpenAI:ApiKey"];

if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("Error: OpenAI API key is not set in user secrets.");
    Console.WriteLine("Please set your OpenAI API key using:");
    Console.WriteLine("dotnet user-secrets set \"OpenAI:ApiKey\" \"your-api-key-here\"");
    return;
}

var client = new OpenAIClient(apiKey);
System.Console.WriteLine("Welcome to Word/Phrase Similarity Calculator using OpenAI Embeddings!");
Console.WriteLine("This program calculates the cosine similarity between two words or phrases using OpenAI's text embeddings using text-embedding-3-large.");
Console.WriteLine("To exit program, simply press Ctrl+C or close the console window. or type '/exit' or '/bye' at any prompt.\n");


while (true)
{
    Console.WriteLine("Enter the first word/phrase:");
    string word1 = Console.ReadLine()?.Trim() ?? string.Empty;
    if (word1.Equals("/exit", StringComparison.OrdinalIgnoreCase) || 
        word1.Equals("/bye", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Exiting the program. Goodbye!");
        break;
    }
    if (string.IsNullOrWhiteSpace(word1))
    {
        Console.WriteLine("Input cannot be empty. Please enter a valid word or phrase.");
        continue;
    }

    Console.WriteLine("Enter the second word/phrase:");
    string word2 = Console.ReadLine()?.Trim() ?? string.Empty;
    if (word2.Equals("/exit", StringComparison.OrdinalIgnoreCase) || 
        word2.Equals("/bye", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Exiting the program. Goodbye!");
        break;
    }

    if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
    {
        Console.WriteLine("Both words/phrases are required.");
        return;
    }

    try
    {
        // Get embeddings for both words
        var embedding1 = await GetEmbeddingAsync(client, word1);
        var embedding2 = await GetEmbeddingAsync(client, word2);

        // Calculate cosine similarity
        double similarity = CalculateCosineSimilarity(embedding1, embedding2);
        
        Console.WriteLine($"\nCosine similarity between '{word1}' and '{word2}': {similarity:F4}");
        Console.WriteLine($"Similarity percentage: {(similarity * 100):F2}%");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static async Task<Vector<float>> GetEmbeddingAsync(OpenAIClient client, string text)
{
    var options = new EmbeddingsOptions("text-embedding-3-large", new[] { text });
    var response = await client.GetEmbeddingsAsync(options);
    return Vector<float>.Build.Dense(response.Value.Data[0].Embedding.ToArray());
}

static double CalculateCosineSimilarity(Vector<float> vector1, Vector<float> vector2)
{
    Console.WriteLine($"Vector 1:\n:{vector1}");
    Console.WriteLine($"Vector 2:\n:{vector2}");
    return vector1.DotProduct(vector2) / (vector1.L2Norm() * vector2.L2Norm());
}
