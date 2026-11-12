static class GitHubUserActivityUtility
{
    public static void PrintUserActivity(this GitHubEvent[] gitHubEvents)
    {
        foreach (var item in gitHubEvents)
        {
            WriteColoredMessage($"activity type: {item.Type}\n", ConsoleColor.DarkCyan);
            WriteColoredMessage($"payload: {item.Payload}\n", ConsoleColor.DarkBlue);
        }
        System.Console.WriteLine();
    }

    public static void WelcomeMessage()
    {
        WriteColoredMessage(
            "Welcome to the git hub user activity CLI, type the user name you want to get git hub activity for, to quit type stop\n",
            ConsoleColor.Magenta
        );
    }

    public static void WriteColoredMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
}
