// See https://aka.ms/new-console-template for more information
// Access the Singleton ConfigurationManager instance
ConfigurationManager config = ConfigurationManager.Instance;

// Get configuration settings
Console.WriteLine($"AppName: {config.GetSetting("AppName")}");
Console.WriteLine($"Version: {config.GetSetting("Version")}");
Console.WriteLine($"MaxUsers: {config.GetSetting("MaxUsers")}");

// Update a setting
config.SetSetting("MaxUsers", "200");

// Save changes (optional)
config.SaveConfiguration();

// Verify updated setting
Console.WriteLine($"Updated MaxUsers: {config.GetSetting("MaxUsers")}");
