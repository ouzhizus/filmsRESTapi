using Microsoft.AspNetCore.Mvc;

namespace filmsRESTapi.Service
{
    public interface IFilmsService
    {
        Task<List<Films>> GetAllFilms();
        Task<Films> GetFilmsById(int id);
        Task<List<Films>> DeleteById(int id);
        Task<List<Films>> DeleteAllFilms();
        Task<List<Films>> AddNewFilm(Films film);
        Task<Films>UpdateFilm(Films film);
    }
}
