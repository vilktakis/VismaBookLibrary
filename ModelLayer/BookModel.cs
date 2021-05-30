using System;

namespace ModelLayer
{
    public class BookModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string PublicationData { get; set; }
        public string ISBN { get; set; }
        public bool Taken { get; set; }
        public int DaysRented { get; set; }
        public DateTime DateTaken { get; set; }
    }
}
