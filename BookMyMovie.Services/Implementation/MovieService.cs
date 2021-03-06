using AutoMapper;
using BookMyMovie.DB;
using BookMyMovie.Models;
using BookMyMovie.Services.Interface;
using BookMyMovie.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyMovie.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly BookMyMovieDbContext _bookDbContext;
        private readonly IMapper _mapper;
        public MovieService(BookMyMovieDbContext bookDbContext, IMapper mapper)
        {
            _bookDbContext = bookDbContext;
            this._mapper = mapper;
        }
        public MovieView AddMovie(MovieView movie)
        {
            try
            {
                var movieModel = _mapper.Map<Movie>(movie);
                _bookDbContext.Movies.Add(movieModel);
                _bookDbContext.SaveChanges();
                return movie;
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred while saving in database");
            }
        }
        public async Task<List<MovieNameView>> GetMovieByLanguage(string movieName)
        {

            var movie = await _bookDbContext.Movies

                 .Where(x => x.MovieName == movieName)
                 .Select(x => new MovieNameView { MovieName = x.MovieName })
                .ToListAsync();
            if (movie != null)
            {
                var movieNamesList = _mapper.Map<List<MovieNameView>>(movie);
                return movieNamesList;
            }
            throw new Exception("Error occurred while fetching details from database");
        }

        public async Task<List<MovieNameView>> GetMovieNames()
        {
            var moviesNames = await _bookDbContext.Movies
                .ToListAsync();
            if (moviesNames != null)
            {
                var NamesList = _mapper.Map<List<MovieNameView>>(moviesNames);
                return NamesList;
            }
            else
            {
                throw new Exception("Error occurred while fetching details from database");
            }
        }
        public async Task<List<MovieView>> GetMoviesDetails()
        {
            var moviesList = await _bookDbContext.Movies
                 .Include(x=>x.ShowTimes).ToListAsync();
            if(moviesList != null) 
            {
                var resultList = _mapper.Map<List<MovieView>>(moviesList);
                return resultList;
            }
            else
            {
                throw new Exception("Error occurred while fetching details from database");
            }
        }

        public MovieView GetMovieDetailByName(string movieName)
        {

            var movie = _bookDbContext.Movies.Include(x => x.ShowTimes).Where(x => x.MovieName == movieName).FirstOrDefault();        
            var movieFetched = _mapper.Map<MovieView>(movie);
            return movieFetched;
        }

        public async Task<List<MovieNameView>> GetMoviesByDirector(string director)
        {
            var movie = await _bookDbContext.Movies.Where(x => x.Director == director).ToListAsync();
            var result = _mapper.Map<List<MovieNameView>>(movie);
            return result;
        }

        public async Task<List<MovieGenreViewModel>> GetMoviesByGenre(string genre)
        {
            var genreList = await _bookDbContext.Movies.Where(x => x.Genre == genre).ToListAsync();
            var genreMap = _mapper.Map<List<MovieGenreViewModel>>(genreList);
            return genreMap;
        }
        public async Task<List<MovieLanguageViewModel>> GetMoviesByLanguage(string language)
        {

            var movieLanguage = await _bookDbContext.Movies.Where(x => x.Language == language).ToListAsync();
            var movieLanguageMap = _mapper.Map<List<MovieLanguageViewModel>>(movieLanguage);
            return movieLanguageMap;
        }

        public MovieByIdView GetMovieById(long id)
        {

            var movie = _bookDbContext.Movies.Include(x=>x.ShowTimes).Where(x => x.Id == id).FirstOrDefault();
            var movieFetched = _mapper.Map<MovieByIdView>(movie);
            return movieFetched;
        }

        public ActorByMovieName GetActors(string movieName)
        {

            var movieActor = _bookDbContext.Movies.Where(x => x.MovieName == movieName).FirstOrDefault();
            var actorFetched = _mapper.Map<ActorByMovieName>(movieActor);
            return actorFetched;
        }

        public string DeleteMovie(long Id)
        {
            var findMovie = _bookDbContext.Movies.Where(a => a.Id == Id).FirstOrDefault();
            if (findMovie != null)
            {
                _bookDbContext.Movies.Remove(findMovie);
                _bookDbContext.SaveChanges();
                return "Movie is deleted successfully";
            }
            return "Movie not Found";
        }

        public UpdateMovieView UpdateMovie(UpdateMovieView movie)
        {
            var movieModel = _bookDbContext.Movies.Where(x => x.Id == movie.MovieId).FirstOrDefault();
            if (movieModel == null)
            {
                throw new Exception("Movie Id not found");
            }
            var result = _mapper.Map(movie, movieModel);
            _bookDbContext.Movies.Update(result);
            _bookDbContext.SaveChanges();

            return movie;
        }
    }
}
