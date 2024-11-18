using BooksAndGenre.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndGenre.Interfaces
{
    public interface IBookService
    {
        Task<IActionResult> GetAllBooks();
        Task<IActionResult> GetInfoByID(int ID_Book);
        Task<IActionResult> CreateNewBook(Books newBook);
        Task<IActionResult> UpdateBook(int ID_Book, Books book);
        Task<IActionResult> DeleteBook(int ID_Book);
        Task<IActionResult> GetBooksByZhanr(string Namezhanr);
        Task<IActionResult> GetBookNameAuthor(string? Authorbook, string? Namebook);
        Task<IActionResult> BooksPagination(int page, int pageSize);
        Task<IActionResult> SearchOrFilter(string author, int? genreId, int? year);
    }
}
