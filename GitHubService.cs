using System.Net.Http.Json;

class GitHubService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<GitHubEvent[]> GetUserRecentActivity(
        string username,
        CancellationToken ct = default
    )
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<GitHubEvent[]>(
                $"https://api.github.com/users/{username}/events",
                ct
            );
            if (result is null)
            {
                throw new UserNotFoundException($"username: {username} not found!");
            }
            return result;
        }
        catch
        {
            throw;
        }
    }
}
