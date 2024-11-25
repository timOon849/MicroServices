using BooksAndGenre.DB;
using BooksAndGenre.Interfaces;
using BooksAndGenre.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksAndGenre.Services
{
    public class GenreService : IGenreService
    {
        private readonly DBCon _context;
        public GenreService(DBCon context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateNewZhanr(Genre newZhanr)
        {
            var zhanr = new Genre()
            {
                Name_Genre = newZhanr.Name_Genre
            };

            await _context.Genre.AddAsync(zhanr);
            await _context.SaveChangesAsync();
            return new OkObjectResult(zhanr);
        }

        public async Task<IActionResult> DeleteZhanr(int ID_Zhanr)
        {
            var tecZhanr = await _context.Books.FindAsync(ID_Zhanr);
            if (tecZhanr != null)
            {
                _context.Remove(tecZhanr);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            else
            {
                return new BadRequestObjectResult("Жанр с данным ID не найден или уже удалёен");
            }
        }

        public async Task<IActionResult> GetallZhanrs()
        {
            var zhanrs = await _context.Genre.ToListAsync();
            if (zhanrs != null)
            {
                return new OkObjectResult(zhanrs);
            }
            else
            {
                return new NotFoundObjectResult("Жанров не обнаружено");
            }
        }

        public async Task<IActionResult> UpdateBook(int ID_Zhanr, Genre zhanr)
        {
            var tecZhanr = await _context.Genre.FindAsync(ID_Zhanr);

            if (tecZhanr != null)
            {
                tecZhanr.Name_Genre = zhanr.Name_Genre;
                await _context.SaveChangesAsync();
                return new OkObjectResult(tecZhanr);
            }
            else
            {
                return new BadRequestObjectResult("Жанр с данным ID не найден");
            }
        }
    }
}
