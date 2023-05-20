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

}