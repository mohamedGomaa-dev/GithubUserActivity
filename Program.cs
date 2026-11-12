var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

var service = new GitHubService(httpClient);

GitHubUserActivityUtility.WelcomeMessage();
while (true)
{
    GitHubUserActivityUtility.WriteColoredMessage("github-activity ", ConsoleColor.DarkGreen);
    var command = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(command))
    {
        GitHubUserActivityUtility.WriteColoredMessage(
            "Enter a valid user name or type stop to quit\n",
            ConsoleColor.Red
        );
        continue;
    }
    if (command.Trim().Equals("stop", StringComparison.OrdinalIgnoreCase))
    {
        GitHubUserActivityUtility.WriteColoredMessage(
            "stopping the application...",
            ConsoleColor.DarkYellow
        );
        break;
    }
    try
    {
        var result = await service.GetUserRecentActivity(command.Trim());
        if (result.Length > 0)
        {
            result.PrintUserActivity();
        }
        else
        {
            GitHubUserActivityUtility.WriteColoredMessage(
                "No Recent Activities\n",
                ConsoleColor.Gray
            );
        }
    }
    catch (Exception ex)
    {
        GitHubUserActivityUtility.WriteColoredMessage(ex.Message, ConsoleColor.DarkRed);
        Console.WriteLine();
        continue;
    }
}
