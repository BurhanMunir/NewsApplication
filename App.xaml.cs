using NewsApplication.ViewModel;
using NewsApplication.Views;

namespace NewsApplication;

public partial class App : Application {
  
    public App(LandingViewModel viewModel) {
        InitializeComponent();

        MainPage = new NavigationPage(new LandingPage(viewModel));
    }

}
