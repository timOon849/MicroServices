using BooksAndGenre.Model;
using Microsoft.AspNetCore.Mvc;
using BooksAndGenre.Interfaces;
using System;

namespace BooksAndGenre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _zhanrService;

        public GenreController(IGenreService zhanrService)
        {
            _zhanrService = zhanrService;
        }

        //o Получение списка всех жанров.
        [HttpGet]
        [Route("GetAllZhanrs")]
        public async Task<IActionResult> GetallZhanrs()
        {
            return await _zhanrService.GetallZhanrs();
        }

        //o Добавление нового жанра.
        [HttpPost]
        [Route("CreateNewZhanr")]
        public async Task<IActionResult> CreateNewZhanr(Genre newZhanr)
        {
            return await _zhanrService.CreateNewZhanr(newZhanr);
        }

        //o   Редактирование жанра.
        [HttpPut]
        [Route("UpdateZhanr")]
        public async Task<IActionResult> UpdateBook(int ID_Zhanr, Genre zhanr)
        {
            return await _zhanrService.UpdateBook(ID_Zhanr, zhanr);
        }
        //o Удаление жанра.
        [HttpDelete]
        [Route("DeleteZhanr")]
        public async Task<IActionResult> DeleteZhanr(int ID_Zhanr)
        {
            return await _zhanrService.DeleteZhanr(ID_Zhanr);
        }
    }
}
