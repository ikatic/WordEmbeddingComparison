# Word Embedding Comparison

A .NET console application that uses OpenAI's text-embedding-3-large model to compare the semantic similarity between words or phrases using cosine similarity.

## Features

- Compares semantic similarity between words or phrases using OpenAI's embeddings
- Uses cosine similarity to calculate the relationship between word embeddings
- Secure API key management using .NET user secrets
- Interactive console interface with continuous word comparison
- Displays raw vector data for educational purposes
- Supports exit commands (/exit or /bye)

## Prerequisites

- .NET 9.0 SDK
- OpenAI API key

## Setup

1. Clone the repository
2. Navigate to the project directory:
   ```bash
   cd WordEmbeddingComparison
   ```
3. Set your OpenAI API key using user secrets:
   ```bash
   dotnet user-secrets set "OpenAI:ApiKey" "your-api-key-here"
   ```

## Usage

1. Run the application:
   ```bash
   dotnet run
   ```
2. Enter the first word/phrase when prompted
3. Enter the second word/phrase when prompted
4. View the similarity score, percentage, and vector data
5. Continue comparing words/phrases or type '/exit' or '/bye' to quit

The program will display:
- The raw vector data for both words/phrases
- The cosine similarity score (ranging from 0 to 1)
- The similarity percentage (ranging from 0% to 100%)

## Example Output

```
Welcome to Word/Phrase Similarity Calculator using OpenAI Embeddings!
This program calculates the cosine similarity between two words or phrases using OpenAI's text embeddings using text-embedding-3-large.
To exit program, simply press Ctrl+C or close the console window. or type '/exit' or '/bye' at any prompt.

Enter the first word/phrase:
king
Enter the second word/phrase:
queen

Vector 1:
[0.123, 0.456, ...]
Vector 2:
[0.234, 0.567, ...]

Cosine similarity between 'king' and 'queen': 0.5524
Similarity percentage: 55.24%
```

## Interpreting Similarity Scores

The following table provides guidance on how to interpret the cosine similarity scores:

| Cosine Score | Interpretation |
|--------------|----------------|
| 0.95 - 1.00 | Extremely similar (nearly duplicate meaning) |
| 0.90 - 0.95 | Strong semantic similarity |
| 0.85 - 0.90 | Related in meaning |
| 0.75 - 0.85 | Weak to moderate similarity |
| 0.60 - 0.75 | Vaguely related or topically nearby |
| < 0.60 | Likely unrelated |

## Dependencies

- Azure.AI.OpenAI (1.0.0-beta.13)
- MathNet.Numerics (5.0.0)
- Microsoft.Extensions.Configuration.UserSecrets (10.0.0-preview.2.25163.2)

## Notes

- The program uses OpenAI's text-embedding-3-large model for generating word embeddings
- Cosine similarity is used to measure the semantic relationship between words
- Higher similarity scores indicate stronger semantic relationships between words
- The program displays raw vector data to help understand how embeddings work
- You can exit the program at any time by typing '/exit' or '/bye' 