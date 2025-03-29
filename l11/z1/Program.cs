class Program
{
    static void Main(string[] args)
    {
        ConfigManager.Instance.SetConfig("AppName", "My Application");
        ConfigManager.Instance.SetConfig("Version", "1.0.0");

        string appName = ConfigManager.Instance.GetConfig("AppName");
        string version = ConfigManager.Instance.GetConfig("Version");

        Console.WriteLine($"App Name: {appName}");
        Console.WriteLine($"Version: {version}");
    }
}