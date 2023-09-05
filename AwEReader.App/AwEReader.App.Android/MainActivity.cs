using Android.App;
using Android.Content.PM;
using Avalonia.Android;

namespace AwEReader.App.Android;

[Activity
(Label = "AwEReader.App.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
public class MainActivity : AvaloniaMainActivity
{
}
