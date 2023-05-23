using MoviesApp.Services.Interfaces;
using movies_api;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services;

public class MovieService : IMovieService
{
    private readonly IMoviesClient _moviesClient;
    private string api_key;

    public MovieService(IMoviesClient moviesClient)
    {
        _moviesClient = moviesClient;
    }

    public async Task<MovieResponse> GetMovieAsync(int movie_id)
    {
        return await _moviesClient.GetMovieAsync(movie_id);
    }

    public async Task AddFavoriteMovieAsync(FavoritesDto favoriteMovie)
    {
        await _moviesClient.AddFavoriteMovieAsync(favoriteMovie);
    }

    public async Task RemoveFavoriteMovieAsync(FavoritesDto favoriteMovie)
    {
        await _moviesClient.DeleteFavoriteMovieAsync(favoriteMovie);
    }

    public async Task<MoviesResponseDto> GetMoviesByTitleAsync(string title, string? userId)
    {
        return await _moviesClient.GetMoviesByTitleAsync(title, userId);
    }
    
    public async Task<MoviesResponseDto> GetTopFavoriteMovies(string? userId)
    {
        return await _moviesClient.GetTopFavoriteMoviesAsync(userId);
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
}