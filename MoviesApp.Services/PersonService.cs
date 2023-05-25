using movies_api;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services;

public class PersonService : IPersonService
{
    private readonly IPersonsClient _personsClient;

    public PersonService(IPersonsClient personsClient)
    {
        _personsClient = personsClient;
    }
    
    public async Task<PersonDetailsDTO> GetPerson(int personId)
    {
        return await _personsClient.GetPersonAsync(personId);
    }

    public async Task<PersonMovieCreditsDTO> GetPersonMovieCredits(int personId)
    {
        return await _personsClient.GetPersonMoviesAsync(personId);
    }
}