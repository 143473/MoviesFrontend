using movies_api;

namespace MoviesApp.Services.Interfaces;

public interface IPersonService
{
    Task<PersonDetailsDTO> GetPerson(int personId);
    Task<PersonMovieCreditsDTO> GetPersonMovieCredits(int personId);
}