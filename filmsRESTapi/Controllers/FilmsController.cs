using filmsRESTapi.Data;
using filmsRESTapi.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;

namespace filmsRESTapi.Controllers
{
    [ApiController]
    public class FilmsController
    {
        private readonly IFilmsService _filmsService;
        public FilmsController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        [HttpGet("GetAllFilms")]
        public async Task<ActionResult<List<Films>>> GetAllFilms()
        {
            return await _filmsService.GetAllFilms();
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Films>> GetById(int id)
        {
            var result = await _filmsService.GetFilmsById(id);
            if (result == null)
            {
                throw new Exception("Film doesn't exist");
            }
            return result;
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<List<Films>>> DeleteById(int id)
        {
            return await _filmsService.DeleteById(id) ?? throw new InvalidOperationException("Film doesn't exist");
        }

        [HttpPost("AddNewFilm")]
        public async Task<ActionResult<List<Films>>> AddNewFilm(Films film)
        {
            return await _filmsService.AddNewFilm(film) ?? throw new InvalidOperationException("Film doesn't exist");
        }

        [HttpPut("UpdateNewFilm")]
        public async Task<ActionResult<Films>> UpdateNewFilm(Films film)
        {
            return await _filmsService.UpdateFilm(film) ?? throw new InvalidOperationException("Film doesn't exist");
        }
    }
}
