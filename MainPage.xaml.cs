using IdentityModel.OidcClient;
using NewsApplication.Helper;
using NewsApplication.Models;
using NewsApplication.ViewModel;
using NewsApplication.Views;
using Newtonsoft.Json;
using System.Diagnostics;

using System.Net;

namespace NewsApplication;

public partial class MainPage : ContentPage {
    protected NewsViewModel NewsViewModel { get; set; }

    public MainPage() {
        InitializeComponent();

    }
    protected override async void OnAppearing() {
        base.OnAppearing();
        var token = await SecureStorage.GetAsync("AccessToken");
        if (token == null) {
            await GenTokeAsync();
        } else {
            Utils.AccessToken = token;
          //  await Navigation.PushModalAsync(new NewsPage());
        }

    }

    async Task GenTokeAsync() {
        try {
            //var loginResult = await OidcClient.LoginAsync(new LoginRequest());
            WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(

        new Uri("https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/authorize?response_type=code&client_id=69cb4421-acdf-431b-b15c-29ae994081bd&redirect_uri=mobiletestingapp://auth&scope=openid email offline_access 69cb4421-acdf-431b-b15c-29ae994081bd"),
        new Uri("mobiletestingapp://"));
            string grantType = "authorization_code";
            var tokenEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/token";
            var authcode = authResult.Properties["code"];
            List<KeyValuePair<string, string>> values = new();
            values.Add(new KeyValuePair<string, string>("client_id", "69cb4421-acdf-431b-b15c-29ae994081bd"));

            values.Add(new KeyValuePair<string, string>("code", authcode));
            values.Add(new KeyValuePair<string, string>("redirect_uri", authcode));
            values.Add(new KeyValuePair<string, string>("grant_type", grantType));

            FormUrlEncodedContent content = new(values);
            HttpClient client = new HttpClient();

            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.PostAsync(tokenEndpoint, content);

            if (response.StatusCode == HttpStatusCode.OK) {
                StreamReader reader = new StreamReader(response.Content.ReadAsStream());
                var tokenresponse = reader.ReadToEnd();
                Token token = JsonConvert.DeserializeObject<Token>(tokenresponse);
                if (token != null) {
                    await SecureStorage.SetAsync("AccessToken", token.AccessToken);
                    await SecureStorage.SetAsync("RefreshToken", token.RefreshToken);
                }
                //this.AccessToken = token.AccessToken;
                await DisplayAlert("attention", tokenresponse, "Ok");
            } else {
                StreamReader reader = new StreamReader(response.Content.ReadAsStream());

            }
            string accessToken = authResult?.AccessToken;
            //wait DisplayAlert("Attention", loginResult.AccessToken, "Ok");
            //  Debug.WriteLine(loginResult.AccessToken);
        } catch (Exception ex) {

        }
    }
    private async void Button_Clicked(object sender, EventArgs e) {
        try {
            //var loginResult = await OidcClient.LoginAsync(new LoginRequest());
            WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(

        new Uri("https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/authorize?response_type=code&client_id=69cb4421-acdf-431b-b15c-29ae994081bd&redirect_uri=mobiletestingapp://auth&scope=openid email offline_access 69cb4421-acdf-431b-b15c-29ae994081bd"),
        new Uri("mobiletestingapp://"));
            string grantType = "authorization_code";
            var tokenEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/token";
            var authcode = authResult.Properties["code"];
            List<KeyValuePair<string, string>> values = new();
            values.Add(new KeyValuePair<string, string>("client_id", "69cb4421-acdf-431b-b15c-29ae994081bd"));

            values.Add(new KeyValuePair<string, string>("code", authcode));
            values.Add(new KeyValuePair<string, string>("redirect_uri", authcode));
            values.Add(new KeyValuePair<string, string>("grant_type", grantType));

            FormUrlEncodedContent content = new(values);
            HttpClient client = new HttpClient();

            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.PostAsync(tokenEndpoint, content);

            if (response.StatusCode == HttpStatusCode.OK) {
                StreamReader reader = new StreamReader(response.Content.ReadAsStream());
                var tokenresponse = reader.ReadToEnd();
                Token token = JsonConvert.DeserializeObject<Token>(tokenresponse);
                //var token = JsonConvert.DeserializeObject<Token>(this.ResponseBody);
                //this.AccessToken = token.AccessToken;
                if (token != null) {
                   // await Navigation.PushModalAsync(new NewsPage());
                    
                }
            } else {
                StreamReader reader = new StreamReader(response.Content.ReadAsStream());

            }
            string accessToken = authResult?.AccessToken;
            //wait DisplayAlert("Attention", loginResult.AccessToken, "Ok");
            //  Debug.WriteLine(loginResult.AccessToken);
        } catch (Exception ex) {

        }


    }
}

