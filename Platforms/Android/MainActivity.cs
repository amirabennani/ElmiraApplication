using Android.App;
using Android.Content.PM;
using Android.OS;
using ZXing.Mobile;

namespace ElmiraApplication;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Initialize ZXing
        MobileBarcodeScanner.Initialize(Application);

        // Other initialization code
    }
}
