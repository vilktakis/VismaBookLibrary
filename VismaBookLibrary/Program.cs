using System;
using ModelLayer;
using LogicLayer;
using System.Threading;

namespace VismaBookLibrary
{
    class Program
    {
        public static BookController controlBook = new BookController();
        public static FilterController controlFilter = new FilterController();
        public static RentingController controlRenting = new RentingController();
        static void Main(string[] args)
        {
            MenuText();
            MainMenu();
        }

        private static void MenuText()
        {
            Console.WriteLine("Hello to a Library program.");
            Console.WriteLine("PLease write on of comands:");
            Console.WriteLine("new - to add a new book");
            Console.WriteLine("rent - to rent a book");
            Console.WriteLine("return - to return a book");
            Console.WriteLine("delete - to delete a book");
            Console.WriteLine("list name - to see the list of books filtherd by name");
            Console.WriteLine("list category - to see the list of books filtherd by category");
            Console.WriteLine("list language - to see the list of books filtherd by language");
            Console.WriteLine("list ISBN - to see the list of books filtherd by ISBN");
            Console.WriteLine("list author - to see the list of books filtherd by author");
            Console.WriteLine("list taken - to see the list of books filtherd by availability");
            Console.WriteLine("quit - to exit the program");
        }

        private static void DayCheck(int days, string isbn, string name)
        {
            if (days < 90)
            {
                
                if(controlRenting.UpdateBook(isbn, days))
                {
                    Console.WriteLine("The book is yours. Enjoy. Press any key.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                }
                else
                {
                    controlRenting.Return(name,  isbn);
                    Console.WriteLine("I am sorry but the book is already taken. Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine("Books can't be rented for 3 months or longer, please choose a difrent amount of days.");
                days = Int16.Parse(Console.ReadLine());
                DayCheck(days, isbn, name);
            }
        }
        private static void MainMenu()
        {
            string isbn;
            string name;
            switch (Console.ReadLine())
            {
                case "new":
                    BookModel book = new BookModel();
                    Console.WriteLine("Name:");
                    book.Name = Console.ReadLine();
                    Console.WriteLine("Author:");
                    book.Author = Console.ReadLine();
                    Console.WriteLine("Category:");
                    book.Category = Console.ReadLine();
                    Console.WriteLine("ISBN:");
                    book.ISBN = Console.ReadLine();
                    Console.WriteLine("Language:");
                    book.Language = Console.ReadLine();
                    Console.WriteLine("Publication date day/month/year, please:");
                    book.PublicationData = Console.ReadLine();
                    book.Taken = false;
                    book.DaysRented = 0;
                    controlBook.CreateBook(book);
                    Console.WriteLine("Book has been added. Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "rent":
                    Console.WriteLine("Please write your name");
                    name = Console.ReadLine();
                    Console.WriteLine("ISBN code of the book please. Only 3 books per person");
                    isbn = Console.ReadLine();
                    if (controlRenting.RentABook(name, isbn))
                    {
                        Console.WriteLine("For how many days would you like to rent we have 3 month limit");
                        int days = Int16.Parse(Console.ReadLine());
                        DayCheck(days, isbn, name);
                    }
                    else
                    {
                        Console.WriteLine("It looks like you have rented your 3 books already.");
                        Console.WriteLine("Please click any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        MenuText();
                        MainMenu();
                    }
                    Console.WriteLine("For how many days?");
                    break;
                case "return":
                    Console.WriteLine("Please write your name");
                    name = Console.ReadLine();
                    Console.WriteLine("ISBN code of the book please.");
                    isbn = Console.ReadLine();
                    if (controlRenting.Return(name, isbn))
                    {
                        if (controlRenting.CheckIfLate(isbn))
                        {
                            Console.WriteLine("One more late book and I promisse I will start breaking knee caps. Please click any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            MenuText();
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("Thank you for returning the book on time. Please click any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            MenuText();
                            MainMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't own us such a book. Please click any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        MenuText();
                        MainMenu();
                    }
                    break;
                case "delete":
                    Console.WriteLine("Please write ISBN for the book");
                    isbn = Console.ReadLine();
                    if (controlBook.DeleteBook(isbn))
                    {
                        Console.WriteLine("the book has been deleted. Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No book with such ISBN. Press any key to continue");
                        Console.ReadKey();
                    }
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "list name":
                    foreach(BookModel var in controlFilter.SortByName())
                    {
                        Console.WriteLine(var.Name+" "+var.Author+" "+var.Language+" "+var.ISBN+" "+var.PublicationData+" "+var.Category+" "+var.Taken);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "list language":
                    foreach (BookModel var in controlFilter.SortByLanguage())
                    {
                        Console.WriteLine(var.Name + " " + var.Author + " " + var.Language + " " + var.ISBN + " " + var.PublicationData + " " + var.Category + " " + var.Taken);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "list ISBN":
                    foreach (BookModel var in controlFilter.SortByISBN())
                    {
                        Console.WriteLine(var.Name + " " + var.Author + " " + var.Language + " " + var.ISBN + " " + var.PublicationData + " " + var.Category + " " + var.Taken);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "list author":
                    foreach (BookModel var in controlFilter.SortByAuthor())
                    {
                        Console.WriteLine(var.Name + " " + var.Author + " " + var.Language + " " + var.ISBN + " " + var.PublicationData + " " + var.Category + " " + var.Taken);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "list category":
                    foreach (BookModel var in controlFilter.SortByCategory())
                    {
                        Console.WriteLine(var.Name + " " + var.Author + " " + var.Language + " " + var.ISBN + " " + var.PublicationData + " " + var.Category + " " + var.Taken);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "list taken":
                    foreach (BookModel var in controlFilter.SortByTaken())
                    {
                        Console.WriteLine(var.Name + " " + var.Author + " " + var.Language + " " + var.ISBN + " " + var.PublicationData + " " + var.Category + " " + var.Taken);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong comand please try again. Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    MenuText();
                    MainMenu();
                    break;
            }
        }
    }
}
