using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ModelLayer;

namespace LogicLayer
{
    public class BookController
    {
        public List<BookModel> books { get; set; } 
        private string fileName = "Books.json";
        public BookController()
        {
            books = new List<BookModel>();
            string jsonString = File.ReadAllText(fileName);
            books = JsonSerializer.Deserialize<List<BookModel>>(jsonString);
        }

        public void CreateBook(BookModel book)
        {
            books.Add(book);
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(fileName, jsonString);
        }

        public bool DeleteBook(string isbn)
        {
            bool x = false;
            foreach (BookModel var in books)
            {
                if (var.ISBN == isbn)
                {
                    books.Remove(var);
                    x = true;
                    break;
                }
            }
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(fileName, jsonString);
            return x;
        }
    }
}
