using NewsApplication.Client;
using NewsApplication.ViewModel;

namespace NewsApplication.Views;

public partial class LandingPage : ContentPage {

    public LandingPage(LandingViewModel viewModel) {
        InitializeComponent();
        IntitliazePages();
        this.BindingContext = viewModel;

    }

    protected  override void OnAppearing() {
        base.OnAppearing();
        
    }

    private async void IntitliazePages() {
        var token = await SecureStorage.GetAsync("AccessToken");
        if (token != null) {
            var page = ActivatorUtilities.CreateInstance<NewsPage>(ServiceProvider.Current);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}