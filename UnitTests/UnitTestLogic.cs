using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using ModelLayer;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestLogic
    {
        [TestMethod]
        public void DeleteBookTest()
        {
            BookModel book = new BookModel();
            book.ISBN = "0";
            BookController controller = new BookController();
            controller.CreateBook(book);
            bool x = controller.DeleteBook(book.ISBN);
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void CreateBookTest()
        {
            BookModel book = new BookModel();
            book.ISBN = "1";
            BookController controller = new BookController();
            controller.CreateBook(book);
            List<BookModel>  books = new List<BookModel>();
            string jsonString = File.ReadAllText("Books.json");
            books = JsonSerializer.Deserialize<List<BookModel>>(jsonString);
            Assert.AreEqual(book.ISBN, books[books.Count-1].ISBN);
        }
    }
}
