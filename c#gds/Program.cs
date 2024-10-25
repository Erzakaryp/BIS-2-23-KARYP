//1 задание

using System;

public abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, int pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }

    public abstract void DisplayInfo();
}

public class FictionBook : Book
{
    public FictionBook(string title, string author, int pages)
        : base(title, author, pages) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Художественная книга: {Title} — {Author}, {Pages} страниц.");
    }
}

public interface IBookOperations
{
    void AddBook(Book book);
    void RemoveBook(string title);
    Book FindBook(string title);
}

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
    }

    public void RemoveBook(string title)
    {
        Book book = FindBook(title);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Книга '{title}' удалена из библиотеки.");
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
        }
    }

    public Book FindBook(string title)
    {
        return books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("Список всех книг в библиотеке:");
        foreach (var book in books)
        {
            book.DisplayInfo();
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        Book book1 = new FictionBook("1984", "Джордж Оруэлл", 328);
        Book book2 = new FictionBook("Мастер и Маргарита", "Михаил Булгаков", 480);

        library.AddBook(book1);
        library.AddBook(book2);

        library.DisplayAllBooks();

        Book foundBook = library.FindBook("1984");
        if (foundBook != null)
        {
            Console.WriteLine("Книга найдена:");
            foundBook.DisplayInfo();
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }

        library.RemoveBook("1984");
        library.DisplayAllBooks();
    }
}


//2 задание
using System;

public abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }

    public abstract void DisplayInfo();
}

public class FictionBook : Book
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Название книги: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Год издания: {YearPublished}");
        Console.WriteLine("Тип книги: Художественная литература");
    }
}

public class NonFictionBook : Book
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Название книги: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Год издания: {YearPublished}");
        Console.WriteLine("Тип книги: Документальная литература");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FictionBook fictionBook = new FictionBook
        {
            Title = "Мастер и Маргарита",
            Author = "Михаил Булгаков",
            YearPublished = 1966
        };
        fictionBook.DisplayInfo();

        Console.WriteLine();

        NonFictionBook nonFictionBook = new NonFictionBook
        {
            Title = "История",
            Author = "Николай",
            YearPublished = 1818
        };
        nonFictionBook.DisplayInfo();
    }
}


//3 задание

using System;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"\"{Title}\" {Author} ({Year})";
    }
}

public interface IBookOperations
{
    void AddBook(Book book);
    bool RemoveBook(string title);
    Book FindBook(string title);
    void DisplayAllBooks();
}

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Книга {book} добавлена в библиотеку.");
    }

    public bool RemoveBook(string title)
    {
        Book bookToRemove = books.FirstOrDefault(b => b.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Книга \"{title}\" удалена из библиотеки.");
            return true;
        }
        Console.WriteLine($"Книга \"{title}\" не найдена.");
        return false;
    }

    public Book FindBook(string title)
    {
        return books.FirstOrDefault(b => b.Title == title);
    }

    public void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
            return;
        }

        Console.WriteLine("Список книг в библиотеке:");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book("1984", "Джордж Оруэлл", 1949));
        library.AddBook(new Book("Убить пересмешника", "Харпер Ли", 1960));
        library.AddBook(new Book("Великий Гэтсби", "Фрэнсис Скотт Фицджеральд", 1925));

        library.DisplayAllBooks();

        var foundBook = library.FindBook("1984");
        Console.WriteLine(foundBook != null
            ? $"Найдена книга: {foundBook}"
            : "Книга не найдена.");

        library.RemoveBook("1984");

        library.DisplayAllBooks();
    }
}

//4 задание

using System;
public interface IBookOperations
{
    void AddBook(Book book);
    void DeleteBook(string title);
    Book SearchBook(string title);
    void SaveToFile(string filename);
    void LoadFromFile(string filename);
}

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Книга успешно добавлена.");
    }

    public void DeleteBook(string title)
    {
        Book bookToDelete = books.Find(b => b.Title == title);
        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);
            Console.WriteLine($"Книга '{title}' успешно удалена.");
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
        }
    }

    public Book SearchBook(string title)
    {
        Book foundBook = books.Find(b => b.Title == title);
        if (foundBook != null)
        {
            Console.WriteLine("Книга найдена:");
            foundBook.DisplayInfo();
            return foundBook;
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
            return null;
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Book book in books)
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.YearPublished},{GetBookType(book)}");
            }
        }
        Console.WriteLine($"Библиотека успешно сохранена в '{filename}'.");
    }

    public void LoadFromFile(string filename)
    {
        books.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Файл '{filename}' не найден.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string title = parts[0];
                    string author = parts[1];
                    int yearPublished = int.Parse(parts[2]);
                    string bookType = parts[3];

                    if (bookType == "Fiction")
                    {
                        books.Add(new FictionBook { Title = title, Author = author, YearPublished = yearPublished, Genre = "Фантастика" });
                    }
                    else if (bookType == "NonFiction")
                    {
                        books.Add(new NonFictionBook { Title = title, Author = author, YearPublished = yearPublished, Subject = "Астрономия" });
                    }
                }
            }
        }
        Console.WriteLine($"Библиотека успешно загружена из '{filename}'.");
    }

    private string GetBookType(Book book)
    {
        if (book is FictionBook)
        {
            return "Fiction";
        }
        else if (book is NonFictionBook)
        {
            return "NonFiction";
        }
        return "Unknown"; // Это не должно происходить
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Год публикации: {YearPublished}");
    }
}

public class FictionBook : Book
{
    public string Genre { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Жанр: {Genre}");
    }
}

public class NonFictionBook : Book
{
    public string Subject { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тематика: {Subject}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new FictionBook { Title = "Хоббит", Author = "Дж. Р. Р. Толкин", YearPublished = 1937, Genre = "Фантастика" });
        library.AddBook(new NonFictionBook { Title = "Космос", Author = "Карл Саган", YearPublished = 1980, Subject = "Астрономия" });

        library.SaveToFile("library.txt");

        library.DeleteBook("Хоббит");

        library.LoadFromFile("library.txt");

        library.SearchBook("Космос");
        library.SearchBook("Хоббит");
    }
}

//5 задание

using System;

public interface IBookOperations
{
    void AddBook(Book book);
    void DeleteBook(string title);
    Book SearchBook(string title);
    Task SaveToFileAsync(string filename);
    Task LoadFromFileAsync(string filename);
}

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Книга успешно добавлена.");
    }

    public void DeleteBook(string title)
    {
        Book bookToDelete = books.Find(b => b.Title == title);
        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);
            Console.WriteLine($"Книга '{title}' успешно удалена.");
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
        }
    }

    public Book SearchBook(string title)
    {
        Book foundBook = books.Find(b => b.Title == title);
        if (foundBook != null)
        {
            Console.WriteLine("Книга найдена:");
            foundBook.DisplayInfo();
            return foundBook;
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
            return null;
        }
    }

    public async Task SaveToFileAsync(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Book book in books)
            {
                await writer.WriteLineAsync($"{book.Title},{book.Author},{book.YearPublished},{GetBookType(book)}");
            }
        }
        Console.WriteLine($"Библиотека успешно сохранена в '{filename}'.");
    }

    public async Task LoadFromFileAsync(string filename)
    {
        books.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Файл '{filename}' не найден.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string title = parts[0];
                    string author = parts[1];
                    int yearPublished = int.Parse(parts[2]);
                    string bookType = parts[3];

                    if (bookType == "Fiction")
                    {
                        books.Add(new FictionBook { Title = title, Author = author, YearPublished = yearPublished, Genre = "Фантастика" });
                    }
                    else if (bookType == "NonFiction")
                    {
                        books.Add(new NonFictionBook { Title = title, Author = author, YearPublished = yearPublished, Subject = "Астрономия" });
                    }
                }
            }
        }
        Console.WriteLine($"Библиотека успешно загружена из '{filename}'.");
    }

    private string GetBookType(Book book)
    {
        if (book is FictionBook)
        {
            return "Fiction";
        }
        else if (book is NonFictionBook)
        {
            return "NonFiction";
        }
        return "Unknown"; // Это не должно происходить
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Год публикации: {YearPublished}");
    }
}

public class FictionBook : Book
{
    public string Genre { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Жанр: {Genre}");
    }
}

public class NonFictionBook : Book
{
    public string Subject { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тематика: {Subject}");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new FictionBook { Title = "Хоббит", Author = "Дж. Р. Р. Толкин", YearPublished = 1937, Genre = "Фантастика" });
        library.AddBook(new NonFictionBook { Title = "Космос", Author = "Карл Саган", YearPublished = 1980, Subject = "Астрономия" });

        await library.SaveToFileAsync("library.txt");

        library.DeleteBook("Хоббит");

        await library.LoadFromFileAsync("library.txt");

        library.SearchBook("Космос");
        library.SearchBook("Хоббит");
    }
}



//6 задание

using System;
public interface IBookOperations
{
    void AddBook(Book book);
    void DeleteBook(string title);
    Book SearchBook(string title);
    void SaveToFile(string filename);
    void LoadFromFile(string filename);
}

public class Library : IBookOperations
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Книга успешно добавлена.");
    }

    public void DeleteBook(string title)
    {
        Book bookToDelete = books.Find(b => b.Title == title);
        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);
            Console.WriteLine($"Книга '{title}' успешно удалена.");
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
        }
    }

    public Book SearchBook(string title)
    {
        Book foundBook = books.Find(b => b.Title == title);
        if (foundBook != null)
        {
            Console.WriteLine("Книга найдена:");
            foundBook.DisplayInfo();
            return foundBook;
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
            return null;
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Book book in books)
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.YearPublished},{GetBookType(book)}");
            }
        }
        Console.WriteLine($"Библиотека успешно сохранена в '{filename}'.");
    }

    public void LoadFromFile(string filename)
    {
        books.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Файл '{filename}' не найден.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string title = parts[0];
                    string author = parts[1];
                    int yearPublished = int.Parse(parts[2]);
                    string bookType = parts[3];

                    if (bookType == "Fiction")
                    {
                        books.Add(new FictionBook { Title = title, Author = author, YearPublished = yearPublished, Genre = "Фантастика" });
                    }
                    else if (bookType == "NonFiction")
                    {
                        books.Add(new NonFictionBook { Title = title, Author = author, YearPublished = yearPublished, Subject = "Астрономия" });
                    }
                }
            }
        }
        Console.WriteLine($"Библиотека успешно загружена из '{filename}'.");
    }

    private string GetBookType(Book book)
    {
        if (book is FictionBook)
        {
            return "Fiction";
        }
        else if (book is NonFictionBook)
        {
            return "NonFiction";
        }
        return "Unknown"; // Это не должно происходить
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Год публикации: {YearPublished}");
    }
}

public class FictionBook : Book
{
    public string Genre { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Жанр: {Genre}");
    }
}

public class NonFictionBook : Book
{
    public string Subject { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тематика: {Subject}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new FictionBook { Title = "Хоббит", Author = "Дж. Р. Р. Толкин", YearPublished = 1937, Genre = "Фантастика" });
        library.AddBook(new NonFictionBook { Title = "Космос", Author = "Карл Саган", YearPublished = 1980, Subject = "Астрономия" });

        library.SaveToFile("library.txt");

        library.DeleteBook("Хоббит");

        library.LoadFromFile("library.txt");

        library.SearchBook("Космос");
        library.SearchBook("Хоббит");
    }
}


