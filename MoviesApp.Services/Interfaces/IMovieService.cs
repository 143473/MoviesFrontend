using movies_api;

namespace MoviesApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieResponseDto> GetMovieAsync(int movie_id);
        Task AddFavoriteMovieAsync(FavoritesDto favoriteMovie);
        Task RemoveFavoriteMovieAsync(FavoritesDto favoriteMovie);
        Task<MovieListDto> GetMoviesByTitleAsync(string title, string? userId);
        Task<MovieListDto> GetTopFavoriteMovies(string? userId);
        Task<RatingDto> GetMovieRatingAsync(int movieId);
        Task AddRatedMovieAsync(RatedMovieDto ratedMovie);
        Task AddRatingAsync(RatedMovieDto ratedMovie);
        Task<MovieListDto> GetFavoriteMovies(string? userId);
        Task<MoviesExtendedResponseDto> GetFilteredMoviesAsync(DateTimeOffset fromDate, DateTimeOffset toDate,
            SortBy sortBy);
    }
}
