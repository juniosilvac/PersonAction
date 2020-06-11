using System;

namespace PersonAction.Model.Context
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
