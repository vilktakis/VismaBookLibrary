using System;
using System.Collections.Generic;
using ModelLayer;

namespace LogicLayer
{
    public class FilterController
    {
        private List<BookModel> books;
        private BookController bookController;
        public FilterController()
        {
            bookController = new BookController();
            books = bookController.books;
        }
        public List<BookModel> SortByName()
        {
            books.Sort(delegate (BookModel x, BookModel y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
            return books;
        }

        public List<BookModel> SortByTaken()
        {
            books.Sort(delegate (BookModel x, BookModel y)
            {
                return y.Taken.CompareTo(x.Taken);
            });
            return books;
        }

        public List<BookModel> SortByLanguage()
        {
            books.Sort(delegate (BookModel x, BookModel y)
            {
                if (x.Language == null && y.Language == null) return 0;
                else if (x.Language == null) return -1;
                else if (y.Language == null) return 1;
                else return x.Language.CompareTo(y.Language);
            });
            return books;
        }

        public List<BookModel> SortByCategory()
        {
            books.Sort(delegate (BookModel x, BookModel y)
            {
                if (x.Category == null && y.Category == null) return 0;
                else if (x.Category == null) return -1;
                else if (y.Category == null) return 1;
                else return x.Category.CompareTo(y.Category);
            });
            return books;
        }

        public List<BookModel> SortByISBN()
        {
            books.Sort(delegate (BookModel x, BookModel y)
            {
                if (x.ISBN == null && y.ISBN == null) return 0;
                else if (x.ISBN == null) return -1;
                else if (y.ISBN == null) return 1;
                else return x.ISBN.CompareTo(y.ISBN);
            });
            return books;
        }

        public List<BookModel> SortByAuthor()
        {
            books.Sort(delegate (BookModel x, BookModel y)
            {
                if (x.Author == null && y.Author == null) return 0;
                else if (x.Author == null) return -1;
                else if (y.Author == null) return 1;
                else return x.Author.CompareTo(y.Author);
            });
            return books;
        }
    }
}
