using System;
using System.Collections.Generic;

public class ConfigManager
{
    private static readonly ConfigManager _instance = new ConfigManager();

    private readonly Dictionary<string, string> _configurations;

    private ConfigManager()
    {
        _configurations = new Dictionary<string, string>();
    }

    public static ConfigManager Instance
    {
        get { return _instance; }
    }

    public void SetConfig(string key, string value)
    {
        _configurations[key] = value;
    }

    public string GetConfig(string key)
    {
        _configurations.TryGetValue(key, out var value);
        return value;
    }
}