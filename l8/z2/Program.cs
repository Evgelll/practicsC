using System;
using System.Text.Json;

public class ParsingException : Exception
{
    public ParsingException(string message, Exception innerException)
        : base(message, innerException) { }
}

public class JsonParser
{
    public void Parse(string json)
    {
        try
        {
            JsonSerializer.Deserialize<object>(json);
        }
        catch (JsonException ex)
        {
            throw new JsonException("Ошибка при парсинге JSON строки", ex);
        }
    }
}

public class DataProcessor
{
    private readonly JsonParser _parser;

    public DataProcessor()
    {
        _parser = new JsonParser();
    }

    public void ProcessJson(string jsonInput)
    {
        try
        {
            _parser.Parse(jsonInput);
            Console.WriteLine("JSON успешно обработан.");
        }
        catch (Exception ex)
        {
            var parsingException = new ParsingException(
                "Не удалось обработать JSON данные",
                ex);

            LogException(parsingException);

            throw parsingException;
        }
    }

    private void LogException(Exception ex)
    {
        Console.WriteLine("--- Лог исключения ---");
        Console.WriteLine($"Сообщение: {ex.Message}");
        Console.WriteLine($"Тип исключения: {ex.GetType().Name}");
        Console.WriteLine($"Стек вызовов: {ex.StackTrace}");

        if (ex.InnerException != null)
        {
            Console.WriteLine("\n--- Внутреннее исключение ---");
            Console.WriteLine($"Сообщение: {ex.InnerException.Message}");
            Console.WriteLine($"Тип: {ex.InnerException.GetType().Name}");
            Console.WriteLine($"Стек вызовов: {ex.InnerException.StackTrace}");
        }
        Console.WriteLine("--------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var processor = new DataProcessor();

        try
        {
            processor.ProcessJson("{ invalid json }");
        }
        catch (ParsingException ex)
        {
            Console.WriteLine("Исключение поймано в Main:");
            Console.WriteLine($"Сообщение: {ex.Message}");
            Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
        }
    }
}