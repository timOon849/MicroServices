using BooksAndGenre.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BooksAndGenre.Interfaces
{
    public interface IGenreService
    {
        Task<IActionResult> GetallZhanrs();
        Task<IActionResult> CreateNewZhanr(Genre newZhanr);
        Task<IActionResult> UpdateBook(int ID_Zhanr, Genre zhanr);
        Task<IActionResult> DeleteZhanr(int ID_Zhanr);
    }
}
