using CommunityToolkit.Mvvm.Messaging;
using NewsApplication.Client;

using NewsApplication.Models;
using NewsApplication.ViewModel;
using System.Collections.ObjectModel;

namespace NewsApplication.Views;

public partial class NewsPage : ContentPage {


    public NewsPage(NewsViewModel viewModel) {
        InitializeComponent();

        this.BindingContext = viewModel;
        btnList.ItemsSource = buttonCards;
        WeakReferenceMessenger.Default.Register<RefreshTokenExpireMessage>(this, async (r, m) => {
            await Navigation.PopToRootAsync();

        });
    }
    ObservableCollection<PageCard> buttonCards = new ObservableCollection<PageCard>() {
    new PageCard()
    {PageNumber="1",
    Index=0,
    BackgroundColor=Colors.White},
    new PageCard()
    {
    PageNumber="2"   ,
    Index=1,
    BackgroundColor=Colors.White},
    new PageCard()
    {PageNumber = "3", Index = 2, BackgroundColor = Colors.White},
    new PageCard()
    {PageNumber = "4", Index = 3, BackgroundColor = Colors.White},
    new PageCard()
    {PageNumber = "5", Index = 4, BackgroundColor = Colors.White},
    };



    protected override void OnAppearing() {
        base.OnAppearing();

    }


    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {
        if (e.Parameter != null) {
            var url = e.Parameter.ToString();

            await Navigation.PushAsync(new NavigationPage(new NewsDetailPage(url)));
        }
    }

    private void btnList_SelectionChanged(object sender, SelectionChangedEventArgs e) {

    }

    private void btnCard_Clicked(object sender, EventArgs e) {
        var btn = (Button)sender;
        btn.BackgroundColor = Colors.Green;
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e) {
        await Navigation.PushAsync(new UserDetailPage());
    }
}