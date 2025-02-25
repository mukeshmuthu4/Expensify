using ExpensifyApp.Helpers;

namespace ExpensifyApp.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            await AppLoadActivityHelper.DoAppInitWork();
        }
        catch (Exception ex)
        {
            await UIHelper.HandleException(ex);
        }
    }
    private async void loginButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage());
    }
}