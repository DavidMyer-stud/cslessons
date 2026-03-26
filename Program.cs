using System;
using System.IO;

namespace Task1
{
    public delegate string TextOperation(string text);

    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "textPD22.txt";
            string outputFile = "resultPD22.txt";

            File.WriteAllText(outputFile, "--- Результати виконання операцій ---\n");

            ProcessFile(inputFile, outputFile, ToUpperCase);
            ProcessFile(inputFile, outputFile, CountCharacters);
            ProcessFile(inputFile, outputFile, CountWords);

            Console.WriteLine("Завдання 1 виконано!");
        }

        static void ProcessFile(string inputFilePath, string outputFilePath, TextOperation operation)
        {
            string text = File.ReadAllText(inputFilePath);
            string result = operation(text);
            File.AppendAllText(outputFilePath, result + Environment.NewLine + "------------------------" + Environment.NewLine);
        }

        static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        static string CountCharacters(string text)
        {
            return $"Кількість символів: {text.Length}";
        }

        static string CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return $"Кількість слів: {words.Length}";
        }
    }
}