using BooksAndGenre.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndGenre.Interfaces
{
    public interface IBookService
    {
        Task<IActionResult> GetAllBooks();
        Task<IActionResult> GetInfoByID(int ID_Book);
        Task<IActionResult> CreateNewBook([FromBody] Books newBook);
        Task<IActionResult> UpdateBook([FromQuery] int ID_Book, [FromBody] Books UpdateBook);
        Task<IActionResult> DeleteBook(int ID_Book);
        Task<IActionResult> GetBooksByZhanr(string Namezhanr);
        Task<IActionResult> GetBookNameAuthor(string? Authorbook, string? Namebook);
        Task<IActionResult> BooksPagination([FromQuery] int page, [FromQuery] int pageSize);
        Task<IActionResult> SearchOrFilter([FromQuery] string author, [FromQuery] int? genreId, [FromQuery] int? year);
    }
}
