using filmsRESTapi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace filmsRESTapi.Service
{
    public class FilmsService : IFilmsService
    {
        private readonly DataContext _dataContext;
        public FilmsService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<List<Films>> GetAllFilms()
        {
            var result = await _dataContext.Films.ToListAsync();
            return result;
        }

        public async Task<Films> GetFilmsById(int id)
        {
            var result = await _dataContext.Films.FindAsync(id);
            if (result == null) return null;
            return result;
        }

        public async Task<List<Films>> DeleteById(int id)
        {
            var result = await _dataContext.Films.FindAsync(id);
            if (result == null) return null;
            _dataContext.Films.Remove(result);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Films.ToListAsync();
        }

        public async Task<List<Films>> DeleteAllFilms()
        {
            _dataContext.Films.RemoveRange(_dataContext.Films);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Films.ToListAsync();
        }

        public async Task<List<Films>> AddNewFilm(Films film)
        {
            await _dataContext.Films.AddAsync(film);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Films.ToListAsync();
        }

        public async Task<Films> UpdateFilm(Films film)
        {
            var result = await _dataContext.Films.FindAsync(film.Id);
            if (result == null)
            {
                return null;
            }
            result.Id = film.Id;
            result.Description = film.Description;
            result.Title = film.Title;
            result.Rating = film.Rating;
            await _dataContext.SaveChangesAsync();
            return result;
        }
    }
}
