namespace NewsApplication.Views;

public partial class NewsDetailPage : ContentPage {
    public NewsDetailPage(string url) {

        InitializeComponent();
        webView.Source = url;
    }
}