using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Webkit;

namespace NewsApplication.Platforms.Android {
    [Activity(Exported =true, NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataScheme = CALLBACK_SCHEME),
        ]
    public class NewsApplicationWebAuthenticatorCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity  {
        const string CALLBACK_SCHEME= "mobiletestingapp";
    }
}
