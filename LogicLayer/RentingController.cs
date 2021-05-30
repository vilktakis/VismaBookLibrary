using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ModelLayer;

namespace LogicLayer
{
    public class RentingController
    {
        private List<BookModel> books;
        private List<ClientModel> clients;
        private BookController bookController;
        private string fileName1 = "Client.json";
        private string fileName2 = "Books.json";
        public RentingController()
        {
            bookController = new BookController();
            books = bookController.books;
            clients = new List<ClientModel>();
            string jsonString = File.ReadAllText(fileName1);
            clients = JsonSerializer.Deserialize<List<ClientModel>>(jsonString);
        }

        public bool RentABook(string name, string isbn)
        {
            foreach (ClientModel var in clients)
            {
                if (var.Name == name)
                {
                    if (var.Books1ISBN == null)
                    {
                        var.Books1ISBN = isbn;
                        string y = JsonSerializer.Serialize(clients);
                        File.WriteAllText(fileName1, y);
                        return true;
                    }
                    else if (var.Books2ISBN == null)
                    {
                        var.Books2ISBN = isbn;
                        string y = JsonSerializer.Serialize(clients);
                        File.WriteAllText(fileName1, y);
                        return true;
                    }
                    else if (var.Books3ISBN == null)
                    {
                        var.Books3ISBN = isbn;
                        string y = JsonSerializer.Serialize(clients);
                        File.WriteAllText(fileName1, y);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            ClientModel x = new ClientModel();
            x.Name = name;
            x.Books1ISBN = isbn;
            clients.Add(x);
            string jsonString = JsonSerializer.Serialize(clients);
            File.WriteAllText(fileName1, jsonString);
            return true;
        }

        public bool UpdateBook(string isbn, int days)
        {
            foreach (BookModel var in books)
            {
                if (var.ISBN == isbn && var.Taken == false)
                {
                    var.DateTaken = DateTime.Today;
                    var.DaysRented = days;
                    var.Taken = true;
                    string jsonString = JsonSerializer.Serialize(books);
                    File.WriteAllText(fileName2, jsonString);
                    return true;
                }
            }
            return false;
        }

        public bool Return(string name, string isbn)
        {
            foreach (ClientModel var in clients)
            {
                if (var.Name == name && var.Books1ISBN == isbn)
                {
                    var.Books1ISBN = null;
                    string y = JsonSerializer.Serialize(clients);
                    File.WriteAllText(fileName1, y);
                    return true;
                }
                else if (var.Name == name && var.Books2ISBN == isbn)
                {
                    var.Books2ISBN = null;
                    string y = JsonSerializer.Serialize(clients);
                    File.WriteAllText(fileName1, y);
                    return true;
                }
                else if (var.Name == name && var.Books3ISBN == isbn)
                {
                    var.Books3ISBN = null;
                    string y = JsonSerializer.Serialize(clients);
                    File.WriteAllText(fileName1, y);
                    return true;
                }
            }
            return false;
        }

        public bool CheckIfLate(string isbn)
        {
            foreach (BookModel var in books)
            {
                if (var.ISBN == isbn && var.Taken == true)
                {
                    bool x = true;
                    if (var.DateTaken.AddDays(var.DaysRented) > DateTime.Today)
                    {
                        var.DaysRented = 0;
                        var.Taken = false;
                        string jsonString = JsonSerializer.Serialize(books);
                        File.WriteAllText(fileName2, jsonString);
                        x = false;
                    }
                    else
                    {
                        var.DaysRented = 0;
                        var.Taken = false;
                        string jsonString = JsonSerializer.Serialize(books);
                        File.WriteAllText(fileName2, jsonString);
                    }
                    return x;
                }
            }
            return false;
        }
    }
}
