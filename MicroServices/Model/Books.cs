﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BooksAndGenre.Model
{
    public class Books
    {
        [Key]
        public int ID_Book { get; set; }

        public required string Name { get; set; }
        public string? Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime YearOfIzd { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Zhanr")]
        public int ID_Genre { get; set; }
        public Genre Genre { get; set; }
    }
    public class ApiResponse
    {
        public List<Books> Books { get; set; }
        public bool Status { get; set; }
    }

    public class BookResponse
    {
        public Books Books { get; set; }
    }
}
