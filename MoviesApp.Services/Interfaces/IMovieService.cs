﻿using movies_api;
using MovieResponse = movies_api.MovieResponse;

namespace MoviesApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieResponse> GetMovieAsync(int movie_id);
        Task<MoviesResponseDto> GetMoviesByTitleAsync(string title);
        
        Task<RatingDto> GetMovieRatingAsync(int movieId);
        Task AddRatedMovieAsync(RatedMovieDto ratedMovie);
        Task AddRatingAsync(RatedMovieDto ratedMovie);
    }
}
