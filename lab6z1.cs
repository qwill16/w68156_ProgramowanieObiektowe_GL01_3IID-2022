using System;
using System.Collections.Generic;
using System.Linq;

// Generyczny interfejs IEntity
public interface IEntity<T>
{
    T Id { get; set; }
}

// Interfejs z w³asnoœci¹ daty utworzenia
public interface ICreationDate
{
    DateTime CreationDate { get; set; }
}

// Klasa Book implementuj¹ca interfejsy IEntity i ICreationDate
public class Book : IEntity<int>, ICreationDate
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
    public DateTime CreationDate { get; set; }
}

// Klasa Person implementuj¹ca interfejsy IEntity i ICreationDate
public class Person : IEntity<Guid>, ICreationDate
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    public DateTime CreationDate { get; set; }
}

// Generyczny interfejs IBaseRepository
public interface IBaseRepository<T, TEntity>
    where T : IEntity<TEntity>
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    IEnumerable<T> GetAll();
    T Get(TEntity id);
    void Delete(TEntity id);
}

// Interfejs IBookRepository rozszerzaj¹cy interfejs IBaseRepository
public interface IBookRepository : IBaseRepository<Book, int>
{
    IEnumerable<Book> GetBooksByAuthor(string author);
    IEnumerable<Book> GetBooksByYear(int year);
}

// Interfejs IPersonRepository rozszerzaj¹cy interfejs IBaseRepository
public interface IPersonRepository : IBaseRepository<Person, Guid>
{
    IEnumerable<Book> GetBorrowedBooks(Guid personId);
    void BorrowBook(Guid personId, Book book);
}

// Implementacja IBookRepository
public class BookRepository : IBookRepository
{
    private List<Book> books = new List<Book>();

    public void Create(Book entity)
    {
        books.Add(entity);
    }

    public void Update(Book entity)
    {
        // Implementacja aktualizacji ksi¹¿ki
    }

    public IEnumerable<Book> GetAll()
    {
        return books;
    }

    public Book Get(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public void Delete(int id)
    {
        var bookToDelete = books.FirstOrDefault(b => b.Id == id);
        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);
        }
    }

    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        return books.Where(b => b.Author == author);
    }

    public IEnumerable<Book> GetBooksByYear(int year)
    {
        return books.Where(b => b.YearPublished == year);
    }
}

// Implementacja IPersonRepository
public class PersonRepository : IPersonRepository
{
    private List<Person> people = new List<Person>();

    public void Create(Person entity)
    {
        people.Add(entity);
    }

    public void Update(Person entity)
    {
        // Implementacja aktualizacji osoby
    }

    public IEnumerable<Person> GetAll()
    {
        return people;
    }

    public Person Get(Guid id)
    {
        return people.FirstOrDefault(p => p.Id == id);
    }

    public void Delete(Guid id)
    {
        var personToDelete = people.FirstOrDefault(p => p.Id == id);
        if (personToDelete != null)
        {
            people.Remove(personToDelete);
        }
    }

    public IEnumerable<Book> GetBorrowedBooks(Guid personId)
    {
        var person = Get(personId);
        return person?.BorrowedBooks ?? Enumerable.Empty<Book>();
    }

    public void BorrowBook(Guid personId, Book book)
    {
        var person = Get(personId);
        if (person != null)
        {
            person.BorrowedBooks.Add(book);
        }
    }
}

class Program
{
    static void Main()
    {
        // Przyk³adowe u¿ycie nowych metod
        IBookRepository bookRepository = new BookRepository();
        IPersonRepository personRepository = new PersonRepository();

        // Dodanie ksi¹¿ek
        Book book1 = new Book { Id = 1, Title = "Book 1", Author = "Author A", YearPublished = 2020, CreationDate = DateTime.Now };
        Book book2 = new Book { Id = 2, Title = "Book 2", Author = "Author B", YearPublished = 2021, CreationDate = DateTime.Now };
        bookRepository.Create(book1);
        bookRepository.Create(book2);

        // Dodanie osoby i wypo¿yczenie ksi¹¿ki
        Person person = new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Age = 30, CreationDate = DateTime.Now };
        personRepository.Create(person);
        personRepository.BorrowBook(person.Id, book1);

        // Wyœwietlenie wypo¿yczonych ksi¹¿ek przez osobê
        var borrowedBooks = personRepository.GetBorrowedBooks(person.Id);
        Console.WriteLine($"Books borrowed by {person.FirstName} {person.LastName}:");
        foreach (var borrowedBook in borrowedBooks)
        {
            Console.WriteLine($"- {borrowedBook.Title} by {borrowedBook.Author}");
        }

        // Wyœwietlenie ksi¹¿ek danego autora
        var booksByAuthor = bookRepository.GetBooksByAuthor("Author A");
        Console.WriteLine($"\nBooks by Author A:");
        foreach (var book in booksByAuthor)
        {
            Console.WriteLine($"- {book.Title}, Year: {book.YearPublished}");
        }

        // Wyœwietlenie ksi¹¿ek wydanych w danym roku
        var booksByYear = bookRepository.GetBooksByYear(2021);
        Console.WriteLine($"\nBooks published in 2021:");
        foreach (var book in booksByYear)
        {
            Console.WriteLine($"- {book.Title}, Author: {book.Author}");
        }
    }
}