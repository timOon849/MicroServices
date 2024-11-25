using BooksAndGenre.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using Azure;
using System.Net.Http.Json;

namespace MicroServices.Controllers
{
    public class GenreController : Controller
    {
        private readonly HttpClient _httpClient;

        public GenreController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        [Route("GetallZhanrs")]
        public async Task<IActionResult> GetallZhanrs() 
        {
            
            try
            {
                var zhanr = await _httpClient.GetAsync($"http://localhost:5118/api/Genre/GetallZhanrs");
                zhanr.EnsureSuccessStatusCode();

                // Десериализация в объект ApiResponse
                var apiResponse = await zhanr.Content.ReadFromJsonAsync<APIResponce>();

                if (apiResponse == null || apiResponse.Genre == null)
                {
                    return StatusCode(500, "Ответ от сервиса книг не содержит данных.");
                }

                return Ok(apiResponse.Genre);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Ошибка при выполнении запроса: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return StatusCode(500, $"Ошибка десериализации JSON: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CreateNewZhanr")]
        public async Task<IActionResult> CreateNewZhanr([FromBody] Genre newZhanr)
        {
            try
            {
                var zhanr = await _httpClient.PostAsJsonAsync($"http://localhost:5118/api/Genre/CreateNewZhanr", newZhanr);
                zhanr.EnsureSuccessStatusCode();
                var result = await zhanr.Content.ReadAsStringAsync();
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Ошибка при выполнении запроса: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return StatusCode(500, $"Ошибка десериализации JSON: {ex.Message}");
            }
        }
        [HttpDelete]
        [Route("DeleteZhanr")]
        public async Task<IActionResult> DeleteZhanr(int id)
        {
            try
            {
                var zhanr = await _httpClient.DeleteAsync($"http://localhost:5118/api/Genre/DeleteZhanr/{id}");
                zhanr.EnsureSuccessStatusCode();
                var result = await zhanr.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(result))
                {
                    return StatusCode(500, "Ответ от сервиса книг пустой.");
                }
                return Ok($"Жанр с ID {id} успешно удален.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Ошибка при выполнении запроса: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return StatusCode(500, $"Ошибка десериализации JSON: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateBook")] //РАБОТАЕТ
        public async Task<IActionResult> UpdateBook([FromBody] Genre UpdateZhanr)
        {


            try
            {
                var response = await _httpClient.PutAsJsonAsync("http://localhost:5118/api/Genre/UpdateBook", UpdateZhanr);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return Ok($"Жанр с ID {UpdateZhanr.ID_Genre} успешно обновлен.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Ошибка при выполнении запроса: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return StatusCode(500, $"Ошибка десериализации JSON: {ex.Message}");
            }
        }
    }
}
