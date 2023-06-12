using CommunityToolkit.Mvvm.Messaging;
using NewsApplication.Helper;
using NewsApplication.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;



namespace NewsApplication.Client {
    public class RestClient : IRestClient {
        readonly HttpClient client = new();
        public async Task<string> GenTokenAsync() {
            try {

                WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(

            new Uri("https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/authorize?response_type=code&client_id=69cb4421-acdf-431b-b15c-29ae994081bd&redirect_uri=mobiletestingapp://auth&scope=openid email offline_access 69cb4421-acdf-431b-b15c-29ae994081bd"),
            new Uri("mobiletestingapp://"));
                string grantType = "authorization_code";
                var tokenEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/token";
                var authcode = authResult.Properties["code"].ToString();
                List<KeyValuePair<string, string>> values = new();
                values.Add(new KeyValuePair<string, string>("client_id", "69cb4421-acdf-431b-b15c-29ae994081bd"));

                values.Add(new KeyValuePair<string, string>("code", authcode));
                values.Add(new KeyValuePair<string, string>("redirect_uri", authcode));
                values.Add(new KeyValuePair<string, string>("grant_type", grantType));

                FormUrlEncodedContent content = new(values);
                HttpClient client = new HttpClient();

                HttpResponseMessage response = new HttpResponseMessage();
                response = client.PostAsync(tokenEndpoint, content).Result;

                if (response.StatusCode == HttpStatusCode.OK) {
                    StreamReader reader = new StreamReader(response.Content.ReadAsStream());
                    var tokenresponse = reader.ReadToEnd();
                    Token token = JsonConvert.DeserializeObject<Token>(tokenresponse);

                    return tokenresponse;
                } else {
                    StreamReader reader = new StreamReader(response.Content.ReadAsStream());

                }

            } catch (Exception ex) {
            }
            return null;
        }

        public async Task<string> RefreshToken() {
            try {

                if (Utils.RefreshTokenExpiresIn > DateTime.Now) {
                    string grantType = "refresh_token";
                    var tokenEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/token";
                    var refreshToken = Utils.RefreshToken;
                    List<KeyValuePair<string, string>> values = new();
                    values.Add(new KeyValuePair<string, string>("client_id", "69cb4421-acdf-431b-b15c-29ae994081bd"));
                    values.Add(new KeyValuePair<string, string>("refresh_token", refreshToken));
                    values.Add(new KeyValuePair<string, string>("grant_type", grantType));

                    FormUrlEncodedContent content = new(values);
                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = new HttpResponseMessage();
                    response = client.PostAsync(tokenEndpoint, content).Result;

                    if (response.StatusCode == HttpStatusCode.OK) {
                        StreamReader reader = new StreamReader(response.Content.ReadAsStream());
                        var tokenresponse = reader.ReadToEnd();
                        Token token = JsonConvert.DeserializeObject<Token>(tokenresponse);
                        await SecureStorage.SetAsync("AccessToken", token.AccessToken);
                        return "Token Refreshed";
                    } else {
                        StreamReader reader = new StreamReader(response.Content.ReadAsStream());

                    }
                } else {
                    //Logout and move to landing page and remove all the value...
                    WeakReferenceMessenger.Default.Send(new RefreshTokenExpireMessage("RefreshTokenExpired"));
                    SecureStorage.RemoveAll();
                }



            } catch (Exception ex) {
            }
            return "";
        }

        public async Task GetUserInfo() {
            try {

                WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(

            new Uri("https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/authorize?response_type=code&client_id=69cb4421-acdf-431b-b15c-29ae994081bd&redirect_uri=mobiletestingapp://auth&scope=openid email offline_access 69cb4421-acdf-431b-b15c-29ae994081bd"),
            new Uri("mobiletestingapp://"));
                string grantType = "userinfo";
                var tokenEndpoint = "https://gcb2cdev.b2clogin.com/gcb2cdev.onmicrosoft.com/b2c_1_mobileapptesting/oauth2/v2.0/token";
                var profileinfo = "eyJ2ZXIiOiIxLjAiLCJ0aWQiOiJjMTExNDhmOC0yMDZjLTQzOTAtYTlkYy0wMWU5YzBjMmVmYTMiLCJzdWIiOm51bGwsIm5hbWUiOiJTYXJmcmF6IFNoYWgiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOm51bGwsImlkcCI6bnVsbH0";
                var authcode = authResult.Properties["code"].First().ToString();
                List<KeyValuePair<string, string>> values = new();
                values.Add(new KeyValuePair<string, string>("client_id", "69cb4421-acdf-431b-b15c-29ae994081bd"));
                values.Add(new KeyValuePair<string, string>("profile_info", profileinfo));
                values.Add(new KeyValuePair<string, string>("grant_type", grantType));

                FormUrlEncodedContent content = new(values);
                HttpClient client = new HttpClient();

                HttpResponseMessage response = new HttpResponseMessage();
                response = client.PostAsync(tokenEndpoint, content).Result;

                if (response.StatusCode == HttpStatusCode.OK) {
                    StreamReader reader = new StreamReader(response.Content.ReadAsStream());
                    var tokenresponse = reader.ReadToEnd();
                    Token token = JsonConvert.DeserializeObject<Token>(tokenresponse);
                    await SecureStorage.SetAsync("AccessToken", token.AccessToken);
                } else {
                    StreamReader reader = new StreamReader(response.Content.ReadAsStream());
                    var respons = reader.ReadToEnd();
                }

                string accessToken = authResult?.AccessToken;

            } catch (Exception ex) {
            }
        }

        public async Task<string> GetAsync(string url) {
            try {


                client.DefaultRequestHeaders.Accept.Clear();
                if (!string.IsNullOrEmpty(Utils.AccessToken))
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Utils.AccessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                var response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;


                if (response.StatusCode == HttpStatusCode.Unauthorized) {
                    return "Unauthorized";
                }
                var content = response.Content;
                var resContent = await response.Content.ReadAsStringAsync();
                return resContent;
            } catch (Exception ex) {

            }
            return "";

        }
    }
}
