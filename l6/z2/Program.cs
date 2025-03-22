using System;

public class Author
{
    public string Name { get; set; }

    public Author(string name)
    {
        Name = name;
    }
}

public class TableOfContents
{
    public string[] Chapters { get; set; }

    public TableOfContents(string[] chapters)
    {
        Chapters = chapters;
    }
}

public class Library
{
    public string Name { get; set; }

    public Library(string name)
    {
        Name = name;
    }
}

public class Book
{
    public string Title { get; set; }
    public Author[] Authors { get; set; }
    public TableOfContents Contents { get; private set; }
    public Library Library { get; set; }

    public Book(string title, Author[] authors, string[] chapters, Library library)
    {
        Title = title;
        Authors = authors;
        Contents = new TableOfContents(chapters);
        Library = library;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Библиотека: {Library.Name}");
        Console.Write("Авторы: ");
        foreach (var author in Authors)
        {
            Console.Write($"{author.Name} ");
        }
        Console.WriteLine();
        Console.WriteLine("Содержание:");
        foreach (var chapter in Contents.Chapters)
        {
            Console.WriteLine($" - {chapter}");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        Library myLibrary = new Library("Городская библиотека");

        Author[] authors1 = { new Author("Автор Один"), new Author("Автор Два") };
        Book book1 = new Book("Книга Первая", authors1, new[] { "Глава 1", "Глава 2" }, myLibrary);

        Author[] authors2 = { new Author("Автор Три") };
        Book book2 = new Book("Книга Вторая", authors2, new[] { "Глава 1", "Глава 2", "Глава 3" }, myLibrary);

        Book[] books = { book1, book2 };

        foreach (Book book in books)
        {
            book.DisplayInfo();
        }
    }
}