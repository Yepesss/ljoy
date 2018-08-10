using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ljoy.helper
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
    private static ISettings AppSettings
    {
        get
        {
            return CrossSettings.Current;
        }
    }


    private const string UsernameKey = "username_key";
    private static readonly string SettingsDefault = string.Empty;

        public static string UsernameSettings
        {
            get
            {
                    return AppSettings.GetValueOrDefault(UsernameKey, SettingsDefault);
            }
            set
            {
                    AppSettings.AddOrUpdateValue(UsernameKey, value);
            }
        }

        public static void RemoveUserName(){
            AppSettings.Remove(UsernameKey);
        }
    }
}
