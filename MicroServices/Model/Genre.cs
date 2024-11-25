using System;
using System.ComponentModel.DataAnnotations;

namespace BooksAndGenre.Model
{
    public class Genre
    {
        [Key]
        public int ID_Genre { get; set; }

        public string? Name_Genre { get; set; }
    }
    public class APIResponce
    {
        public List<Genre> Genre { get; set; }
        public bool Status { get; set; }
    }
}
