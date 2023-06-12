using Microsoft.Extensions.Logging;
using NewsApplication.Client;
using NewsApplication.Helper;
using NewsApplication.ViewModel;
using NewsApplication.Views;

namespace NewsApplication;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<IRestClient, RestClient>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<NewsPage>();
        builder.Services.AddTransient<NewsViewModel>();
        builder.Services.AddTransient<LandingPage>();
        builder.Services.AddTransient<LandingViewModel>();
        builder.Services.AddTransient<WebAuthenticatorBrowser>();
        builder.Services.AddTransient<IRestClient, RestClient>();
        //builder.Services.AddTransient<OidcClient>(sp =>
        //    new OidcClient(new OidcClientOptions {
        //        // Use your own ngrok url:
        //        LoadProfile = true,

        //        ProviderInformation = new ProviderInformation {
        //            IssuerName = "mobiletestingapp",
        //            TokenEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/token",
        //            AuthorizeEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/authorize",
        //            KeySet = new IdentityModel.Jwk.JsonWebKeySet()
        //        },
        //        Authority = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/B2C_1_mobileapptesting/v2.0/",

        //        ClientId = "69cb4421-acdf-431b-b15c-29ae994081bd",
        //        RedirectUri = "mobiletestingapp://auth",
        //        Scope = "openid email offline_access 69cb4421-acdf-431b-b15c-29ae994081bd",

        //        Browser = sp.GetRequiredService<WebAuthenticatorBrowser>(),
        //    })
        //);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
