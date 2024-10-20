using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public sealed class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _instance = 
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    private Dictionary<string, string> _settings;

    // Private constructor to prevent direct instantiation
    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
        LoadConfiguration();
    }

    // Global access point to the single instance
    public static ConfigurationManager Instance => _instance.Value;

    // Method to load configuration settings from a file (e.g., config.json)
    private void LoadConfiguration()
    {
        try
        {
            string configFilePath = "config.json";
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                _settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                Console.WriteLine("Config file not found, using default settings.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading configuration: {ex.Message}");
        }
    }

    // Method to get a configuration setting by key
    public string GetSetting(string key)
    {
        if (_settings.ContainsKey(key))
        {
            return _settings[key];
        }

        return null;
    }

    // Method to set or update a configuration setting
    public void SetSetting(string key, string value)
    {
        if (_settings.ContainsKey(key))
        {
            _settings[key] = value;
        }
        else
        {
            _settings.Add(key, value);
        }
    }

    // Save the settings back to the config file (optional)
    public void SaveConfiguration()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText("config.json", json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving configuration: {ex.Message}");
        }
    }
}
