using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int YearOfPublication { get; set; }
}

public class UserManager
{
    private List<User> users = new List<User>();

    public bool Register(string username, string password, string email)
    {
        if (users.Any(u => u.Username == username || u.Email == email))
        {
            Console.WriteLine("User already exists.");
            return false;
        }

        users.Add(new User { Username = username, Password = password, Email = email });
        Console.WriteLine("Registration successful.");
        return true;
    }

    public bool Login(string username, string password)
    {
        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Console.WriteLine("Login successful.");
            return true;
        }

        Console.WriteLine("Login failed. Check your username and password.");
        return false;
    }
}

public class BookManager
{
    private List<Book> books = new List<Book>();

    public void AddBook(string title, string author, string isbn, int yearOfPublication)
    {
        books.Add(new Book { Title = title, Author = author, ISBN = isbn, YearOfPublication = yearOfPublication });
        Console.WriteLine("Book added successfully.");
    }
}

class Program
{
    static UserManager userManager = new UserManager();
    static BookManager bookManager = new BookManager();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Library Management System!");
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Login User");
            Console.WriteLine("3. Add Book");
            Console.WriteLine("4. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    LoginUser();
                    break;
                case "3":
                    AddBook();
                    break;
                case "4":
                    return; // Exit the program
                default:
                    Console.WriteLine("Unknown option.");
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        Console.WriteLine("Enter username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine();
        Console.WriteLine("Enter email:");
        string email = Console.ReadLine();

        userManager.Register(username, password, email);
    }

    static void LoginUser()
    {
        Console.WriteLine("Enter username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine();

        userManager.Login(username, password);
    }

    static void AddBook()
    {
        Console.WriteLine("Enter book title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter author's name:");
        string author = Console.ReadLine();
        Console.WriteLine("Enter ISBN:");
        string isbn = Console.ReadLine();
        Console.WriteLine("Enter year of publication:");
        int yearOfPublication = int.Parse(Console.ReadLine());

        bookManager.AddBook(title, author, isbn, yearOfPublication);
    }
}
