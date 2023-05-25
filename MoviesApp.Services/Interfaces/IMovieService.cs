using movies_api;
using MovieResponse = movies_api.MovieResponse;

namespace MoviesApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieResponse> GetMovieAsync(int movie_id);
        Task AddFavoriteMovieAsync(FavoritesDto favoriteMovie);
        Task RemoveFavoriteMovieAsync(FavoritesDto favoriteMovie);
        Task<MoviesResponseDto> GetMoviesByTitleAsync(string title, string? userId);
        Task<MoviesResponseDto> GetTopFavoriteMovies(string? userId);
        Task<RatingDto> GetMovieRatingAsync(int movieId);
        Task AddRatedMovieAsync(RatedMovieDto ratedMovie);
        Task AddRatingAsync(RatedMovieDto ratedMovie);
        Task<MoviesResponseDto> GetFavoriteMovies(string? userId);
    }
}
