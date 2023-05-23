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
    
    public async Task<MoviesResponseDto> GetMoviesByTitleAsync(string title)
    {
        return await _moviesClient.GetMoviesByTitleAsync(title);
    }
    
    public async Task<MoviesResponseDto> GetFavoriteMovies()
    {
        return await _moviesClient.GetTopFavoriteMoviesAsync();
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