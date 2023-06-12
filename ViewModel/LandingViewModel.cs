using NewsApplication.Client;
using NewsApplication.Models;
using NewsApplication.Views;
using Newtonsoft.Json;
using System.Windows.Input;

namespace NewsApplication.ViewModel {
    public class LandingViewModel : BaseViewModel {

        private IRestClient restClient { get; set; }
       
        public ICommand SignInCommand { get; set; }
        public LandingViewModel(IRestClient _restClient) {
            restClient = _restClient;
            SignInCommand = new Command(async () => {
                try {

                    if (IsBusy)
                        return;
                    IsBusy = true;
                    var response = await restClient.GenTokenAsync();
                    if (response != null) {
                        var token = JsonConvert.DeserializeObject<Token>(response);
                        await SecureStorage.SetAsync("AccessToken", token.AccessToken);
                        await SecureStorage.SetAsync("RefreshToken", token.RefreshToken);
                        await SecureStorage.SetAsync("UserProfile", token.ProfileInfo);
                        await SecureStorage.SetAsync("RefreshTokenExpiresIn", ExpirationDate(token.RefreshTokenExpiresIn));
                        var page = ActivatorUtilities.CreateInstance<NewsPage>(ServiceProvider.Current);
                        await Application.Current.MainPage.Navigation.PushAsync(page);
                    }

                } catch (Exception ex) {

                }
                IsBusy = false;
            });
        }

        string ExpirationDate(int seconds) {
            DateTime currentDate = DateTime.Now;
            DateTime expirationDate = currentDate.AddSeconds(seconds);
            string expirationDateString = expirationDate.ToString("yyyy-MM-dd HH:mm:ss");
            return expirationDateString;
        }
    }
}
