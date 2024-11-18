using BooksAndGenre.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksAndGenre.DB
{
    public class DBCon : DbContext
    {
        public DBCon(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
