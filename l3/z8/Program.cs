using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        var words = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (var word in words)
        {
            string lowerWord = word.ToLower(); 
            if (wordCount.ContainsKey(lowerWord))
            {
                wordCount[lowerWord]++;
            }
            else
            {
                wordCount[lowerWord] = 1;
            }
        }

        var mostFrequentWord = wordCount.OrderByDescending(w => w.Value).FirstOrDefault();

        if (mostFrequentWord.Key != null)
        {
            Console.WriteLine($"Самое часто встречающееся слово: '{mostFrequentWord.Key}' (встречается {mostFrequentWord.Value} раз(а))");
        }
        else
        {
            Console.WriteLine("В строке нет слов.");
        }
    }
}