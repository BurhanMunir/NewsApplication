using NewsApplication.Client;
using NewsApplication.Helper;
using NewsApplication.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NewsApplication.ViewModel {
    public class NewsViewModel : BaseViewModel {
        IRestClient restClient { get; set; }
        public ObservableCollection<News> News { get; set; }
        public ICommand SelectNewsCommand { get; set; }

        public ICommand LogOutCommand { get; set; }


        public NewsViewModel(IRestClient _restClient) {
            restClient = _restClient;
            News = new ObservableCollection<News>();
            OnInit();
            SelectNewsCommand = new Command((item) => {
                var news = item;
            });

            LogOutCommand = new Command(() => {
               
            });
        }
        private News _selectedNews;
        public News SelectedNews {
            get => _selectedNews;
            set {
                _selectedNews = value;
                OnPropertyChanged("SelectedPhoto");
            }
        }
        public async void OnInit() {
            if (IsBusy)
                return;
            IsBusy = true;
            string accessToken = await SecureStorage.GetAsync("AccessToken");
            string tokenRefreshExpiration = await SecureStorage.GetAsync("RefreshTokenExpiresIn");
            Utils.RefreshTokenExpiresIn = DateTime.Parse(tokenRefreshExpiration);
            Utils.AccessToken = accessToken.ToString();
            Utils.RefreshToken = await SecureStorage.GetAsync("RefreshToken");

            GetNews();
            //GetUserInfo();
            IsBusy = false;

        }
        public async void GetNews() {
            try {
                List<News> AllNews = new List<News>();
                var newsResponse = await restClient.GetAsync("https://stazvmapp.southeastasia.cloudapp.azure.com/mauitest/news");
                if (newsResponse == "Unauthorized") {

                    
                  var refreshtoken=  await restClient.RefreshToken();
                    if(refreshtoken== "Token Refreshed") {
                        var news = await restClient.GetAsync("https://stazvmapp.southeastasia.cloudapp.azure.com/mauitest/news");
                        var allnews = JsonConvert.DeserializeObject<List<News>>(news);
                        News.Clear();
                        if (allnews != null) {
                            foreach (var item in allnews) {
                                News.Add(item);
                            }
                            return;
                        }
                    }
                }
                AllNews = JsonConvert.DeserializeObject<List<News>>(newsResponse);
                News.Clear();
                foreach (var item in AllNews) {
                    News.Add(item);
                }
            } catch (Exception ex) {

            }


        }
        public async void GetUserInfo() {
            await restClient.GetUserInfo();
        }
    }
}
