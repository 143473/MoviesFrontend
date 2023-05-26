using MoviesApp.Services.Interfaces;
using movies_api;

namespace MoviesApp.Services;

public class MovieService : IMovieService
{
    private readonly IMoviesClient _moviesClient;
    private string api_key;

    public MovieService(IMoviesClient moviesClient)
    {
        _moviesClient = moviesClient;
    }

    public async Task<MovieResponseDto> GetMovieAsync(string userId, int movie_id)
    {
        return await _moviesClient.GetMovieAsync(movie_id);
    }

    public Task AddFavoriteMovieAsync(FavoritesDto favoriteMovie)
    {
         return _moviesClient.AddFavoriteMovieAsync(favoriteMovie);
    }

    public Task RemoveFavoriteMovieAsync(FavoritesDto favoriteMovie)
    {
        return _moviesClient.DeleteFavoriteMovieAsync(favoriteMovie);
    }

    public Task<MovieListDto> GetMoviesByTitleAsync(string title, string? userId)
    {
        return _moviesClient.GetMoviesByTitleAsync(title, userId);
    }
    
    public Task<MovieListDto> GetTopFavoriteMovies(string? userId)
    {
        return _moviesClient.GetTopFavoriteMoviesAsync(userId);
    }
    
    public Task<MovieListDto> GetFavoriteMovies(string? userId)
    {
        return _moviesClient.GetFavoriteMoviesAsync(userId);
    }

    public Task<MovieCreditsResponseDto> GetMovieCreditsAsync(int movieId)
    {
        return _moviesClient.GetMovieCreditsAsync(movieId);
    }

    public async Task<RatingDto> GetMovieRatingAsync(int movieId)
    {
        return await _moviesClient.GetMovieRatingAsync(movieId);
    }

    public async Task AddRatedMovieAsync(RatedMovieDto ratedMovie)
    {
        await _moviesClient.AddRatedMovieAsync(ratedMovie);
    }

    public async Task AddRatingAsync(RatedMovieDto ratedMovie)
    {
        await _moviesClient.AddRatingAsync(ratedMovie);
    }

    public async Task<MoviesExtendedResponseDto> GetFilteredMoviesAsync(DateTimeOffset fromDate, DateTimeOffset toDate, SortBy sortBy)
    {
        return await _moviesClient.GetFilteredMoviesAsync(fromDate, toDate, sortBy);
    }
}