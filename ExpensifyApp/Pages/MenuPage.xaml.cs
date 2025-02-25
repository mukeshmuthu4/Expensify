using CommunityToolkit.Maui.Views;

namespace ExpensifyApp.Pages;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

    
        private async void OpenPopup(object sender, EventArgs e)
        {
        if (sender is ImageButton button)
        {
            //string category = button.BindingContext as string;
            //var popup = new ExpensePopup(category); // Pass category as a parameter
            //this.ShowPopup(popup);

            ExpensePopup.ShowPopup();

        }


    }

   
}